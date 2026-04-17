using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Validate arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: SlideConverter <inputFile> <targetFormat> [dpi]");
                return;
            }

            string inputPath = args[0];
            string targetFormatString = args[1];
            int dpi = 0;
            if (args.Length >= 3)
            {
                int.TryParse(args[2], out dpi);
            }

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Determine output file path
            string inputDirectory = Path.GetDirectoryName(inputPath);
            string inputFileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputExtension = targetFormatString.ToLowerInvariant();
            if (outputExtension == "tiff")
                outputExtension = "tiff";
            else if (outputExtension == "pdf")
                outputExtension = "pdf";
            else if (outputExtension == "xps")
                outputExtension = "xps";
            else if (outputExtension == "md")
                outputExtension = "md";
            else
                outputExtension = targetFormatString.ToLowerInvariant();

            string outputPath = Path.Combine(inputDirectory ?? "", inputFileNameWithoutExt + "." + outputExtension);

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Parse target format enum
                    SaveFormat targetFormat = (SaveFormat)Enum.Parse(typeof(SaveFormat), targetFormatString, true);

                    // If target is TIFF and DPI is specified, use TiffOptions
                    if (targetFormat == SaveFormat.Tiff && dpi > 0)
                    {
                        TiffOptions tiffOptions = new TiffOptions();
                        tiffOptions.DpiX = (uint)dpi;
                        tiffOptions.DpiY = (uint)dpi;
                        pres.Save(outputPath, targetFormat, tiffOptions);
                    }
                    else
                    {
                        // Simple save without additional options
                        pres.Save(outputPath, targetFormat);
                    }
                }

                Console.WriteLine("Conversion completed: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified target format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}