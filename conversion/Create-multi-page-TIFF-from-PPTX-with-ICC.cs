using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTiffExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output multi‑page TIFF file path
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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure TIFF options
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
                // Example: set compression type
                tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.CCITT4;
                // Example: set DPI if needed
                tiffOptions.DpiX = 300;
                tiffOptions.DpiY = 300;
                // Note: Embedding an ICC profile is not directly exposed via TiffOptions.
                // If required, custom processing of the generated TIFF file would be needed here.

                // Save as multi‑page TIFF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("TIFF file created successfully at: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported format exception
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}