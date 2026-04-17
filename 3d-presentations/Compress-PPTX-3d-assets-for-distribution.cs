using System;
using System.IO;
using Aspose.Slides.Export;

namespace CompressPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_compressed.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Compress embedded fonts (preserves 3D assets)
                Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(presentation);

                // Save the compressed presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();

                Console.WriteLine("Presentation compressed successfully.");
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The presentation format is not supported for compression.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}