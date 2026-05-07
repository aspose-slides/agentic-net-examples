using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchTiffCompression
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if any arguments are provided
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please provide PPT file paths as arguments.");
                return;
            }

            // Process each input file
            foreach (string inputPath in args)
            {
                try
                {
                    // Verify that the file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Load the presentation
                    Presentation presentation = new Presentation(inputPath);

                    // Configure TIFF options: LZW compression and 150 DPI
                    TiffOptions tiffOptions = new TiffOptions();
                    tiffOptions.CompressionType = TiffCompressionTypes.LZW;
                    tiffOptions.DpiX = 150;
                    tiffOptions.DpiY = 150;

                    // Build the output file path
                    string directory = Path.GetDirectoryName(inputPath);
                    string filenameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(directory, filenameWithoutExt + "_compressed.tiff");

                    // Save the presentation as TIFF with the specified options
                    presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                    // Dispose the presentation before exiting the loop
                    presentation.Dispose();

                    Console.WriteLine($"Processed: {inputPath} -> {outputPath}");
                }
                catch (NotSupportedException)
                {
                    // Handle unsupported format
                    Console.WriteLine($"Format not supported for file: {inputPath}");
                }
                catch (Exception ex)
                {
                    // General error handling
                    Console.WriteLine($"Error processing file {inputPath}: {ex.Message}");
                }
            }
        }
    }
}