using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Verify that a source file path was provided
        if (args.Length == 0)
        {
            Console.WriteLine("Please provide the path to the source presentation file as an argument.");
            return;
        }

        string sourcePath = args[0];

        // Check if the input file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine($"Input file does not exist: {sourcePath}");
            return;
        }

        // Define the output TIFF file path
        string outputPath = Path.ChangeExtension(sourcePath, "tiff");

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Create TIFF options
                TiffOptions tiffOptions = new TiffOptions();

                // Set the compression type (example uses CCITT4)
                tiffOptions.CompressionType = TiffCompressionTypes.CCITT4;

                // Apply black‑and‑white conversion only when compression is CCITT3 or CCITT4
                if (tiffOptions.CompressionType == TiffCompressionTypes.CCITT3 ||
                    tiffOptions.CompressionType == TiffCompressionTypes.CCITT4)
                {
                    tiffOptions.BwConversionMode = BlackWhiteConversionMode.Dithering;
                }

                // Save the presentation as a multi‑page TIFF
                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);
            }
        }
        // Handle unsupported file format exceptions
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified file format is not supported.");
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}