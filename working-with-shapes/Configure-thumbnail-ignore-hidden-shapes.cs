using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailGenerator
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            var inputPath = "input.pptx";
            var outputImagePath = "slide_thumbnail.png";
            var outputPresentationPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load presentation
                using (var presentation = new Presentation(inputPath))
                {
                    // Access the first slide
                    var slide = presentation.Slides[0];

                    // Generate thumbnail image (full scale)
                    // Hidden shapes are automatically excluded from rendering
                    var image = slide.GetImage(1f, 1f);
                    image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                    // Save the presentation before exiting
                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}