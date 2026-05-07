using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToTiffExample
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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure TIFF options
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

                // Set slide layout options (each slide on a separate page)
                // Note: Margin of 0.2 inches is not directly exposed; default layout is used.
                tiffOptions.SlidesLayoutOptions = new Aspose.Slides.Export.HandoutLayoutingOptions
                {
                    Handout = Aspose.Slides.Export.HandoutType.Handouts4Horizontal
                };

                // Save the presentation as a multi-page TIFF
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
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