// -----------------------------------------------------------------------------
// Example: Configure thumbnail ignore hidden shapes using C#
//
// Description:
// Demonstrates how to generate a slide thumbnail while automatically ignoring
// hidden shapes using Aspose.Slides for .NET. The example loads a PPTX file,
// creates a PNG thumbnail of the first slide, and saves both the image and the
// (unchanged) presentation. This pattern can be used in console utilities or
// automated workflows that need thumbnail generation without rendering hidden
// objects.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Thumbnail, Ignore,
// Hidden, Shapes, Presentation Processing, Office Automation
//
// Use Cases:
// - Generate slide thumbnails that exclude hidden shapes.
// - Build C# command‑line tools for PowerPoint thumbnail extraction.
// - Integrate thumbnail creation into .NET applications while preserving
//   presentation integrity.
// - Automate batch processing of PPTX files for preview generation.
// -----------------------------------------------------------------------------

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
