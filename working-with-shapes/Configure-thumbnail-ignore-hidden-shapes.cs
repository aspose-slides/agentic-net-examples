using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            var outputImagePath = Path.Combine(Directory.GetCurrentDirectory(), "slide_thumbnail.png");
            var outputPresentationPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                var presentation = new Presentation(inputPath);

                // Access the first slide
                var slide = presentation.Slides[0];

                // Generate thumbnail image (full scale) – hidden shapes are automatically excluded
                var thumbnail = slide.GetImage(1f, 1f);
                thumbnail.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);

                // Save the presentation (required before exit)
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle accordingly
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access, Aspose.Slides errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}