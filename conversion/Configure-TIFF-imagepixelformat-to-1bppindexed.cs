using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TiffConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.tiff";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure TIFF options with 1bpp indexed pixel format for minimal size
                TiffOptions tiffOptions = new TiffOptions();
                tiffOptions.PixelFormat = ImagePixelFormat.Format1bppIndexed;

                // Save the presentation as TIFF using the configured options
                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("Presentation successfully saved as TIFF: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}