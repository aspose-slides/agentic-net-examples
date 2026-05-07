using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MultiPageTiffExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.tiff";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure TIFF options
                TiffOptions tiffOptions = new TiffOptions();
                tiffOptions.CompressionType = TiffCompressionTypes.CCITT4;
                tiffOptions.DpiX = 300;
                tiffOptions.DpiY = 300;

                // TODO: Embed ICC profile for color accuracy
                // (Aspose.Slides currently does not expose a direct property for ICC profile embedding.
                // If such functionality becomes available, set it here, e.g., tiffOptions.IccProfile = ...;)

                // Save as multi‑page TIFF
                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("TIFF file created successfully: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for conversion.
                Console.WriteLine("The file format is not supported for TIFF conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}