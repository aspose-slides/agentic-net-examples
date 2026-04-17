using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input PPT file path
            string inputPath;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Define output TIFF paths
            string tiffPath = Path.Combine(Directory.GetCurrentDirectory(), "output.tif");
            string compressedTiffPath = Path.Combine(Directory.GetCurrentDirectory(), "output_compressed.tif");

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure TIFF options (default LZW compression)
                TiffOptions tiffOptions = new TiffOptions();
                tiffOptions.CompressionType = TiffCompressionTypes.Default;

                // Save presentation as TIFF
                presentation.Save(tiffPath, SaveFormat.Tiff, tiffOptions);

                // Release resources
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for conversion.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during conversion: " + ex.Message);
                return;
            }

            // Compress TIFF using external LZW tool
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "tiffcp"; // External tool placeholder
                psi.Arguments = "-c lzw \"" + tiffPath + "\" \"" + compressedTiffPath + "\"";
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;

                Process proc = Process.Start(psi);
                proc.WaitForExit();

                if (proc.ExitCode != 0)
                {
                    Console.WriteLine("External compression tool failed with exit code: " + proc.ExitCode);
                }
                else
                {
                    Console.WriteLine("Compressed TIFF saved to: " + compressedTiffPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error invoking external compression tool: " + ex.Message);
            }
        }
    }
}