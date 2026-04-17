using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchTiffConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if any file paths are provided
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please provide at least one PowerPoint file path as an argument.");
                return;
            }

            foreach (string inputPath in args)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                try
                {
                    // Load the presentation
                    Presentation presentation = new Presentation(inputPath);

                    // Configure TIFF options: LZW compression and 150 DPI
                    TiffOptions tiffOptions = new TiffOptions();
                    tiffOptions.CompressionType = TiffCompressionTypes.LZW;
                    tiffOptions.DpiX = 150;
                    tiffOptions.DpiY = 150;

                    // Determine output file path (same folder, same name with .tiff extension)
                    string directory = Path.GetDirectoryName(inputPath);
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(directory ?? string.Empty, fileNameWithoutExt + ".tiff");

                    // Save the presentation as TIFF with the specified options
                    presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                    // Dispose the presentation object
                    presentation.Dispose();

                    Console.WriteLine($"Successfully converted to TIFF: {outputPath}");
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"The file format of '{inputPath}' is not supported for conversion.");
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine($"Error processing file '{inputPath}': {ex.Message}");
                }
            }
        }
    }
}