using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
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
                Presentation pres = new Presentation(inputPath);

                // Configure TIFF options for black‑and‑white conversion
                TiffOptions options = new TiffOptions();
                options.CompressionType = TiffCompressionTypes.CCITT4;
                options.BwConversionMode = BlackWhiteConversionMode.Dithering;

                // Save the presentation as a TIFF file with the specified options
                pres.Save(outputPath, SaveFormat.Tiff, options);

                // Clean up resources
                pres.Dispose();

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported file formats
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
            }
        }
    }
}