using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertPptxToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine the directory containing PPTX files
            string inputDirectory;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputDirectory = args[0];
            }
            else
            {
                inputDirectory = Directory.GetCurrentDirectory();
            }

            // Verify that the directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Get all PPTX files in the directory
            string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx", SearchOption.TopDirectoryOnly);
            if (pptxFiles.Length == 0)
            {
                Console.WriteLine("No PPTX files found in directory: " + inputDirectory);
                return;
            }

            foreach (string inputPath in pptxFiles)
            {
                // Verify that the file exists (redundant but follows requirement)
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("File not found: " + inputPath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    Presentation presentation = new Presentation(inputPath);

                    // Configure TIFF options with LZW compression
                    TiffOptions tiffOptions = new TiffOptions();
                    tiffOptions.CompressionType = TiffCompressionTypes.LZW;

                    // Determine output file path (same name with .tiff extension)
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".tiff";
                    string outputPath = Path.Combine(inputDirectory, outputFileName);

                    // Save the presentation as TIFF using the specified options
                    presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                    // Dispose the presentation to release resources
                    presentation.Dispose();

                    Console.WriteLine("Converted: " + inputPath + " -> " + outputPath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    // Comment: format not supported
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., I/O errors)
                    Console.WriteLine("Error processing file " + inputPath + ": " + ex.Message);
                }
            }
        }
    }
}