// -----------------------------------------------------------------------------
// Example: Export slide as PNG 300 dpi using C#
//
// Description:
// Demonstrates how to export the first slide of a PowerPoint presentation
// as a PNG image with a resolution of 300 DPI using Aspose.Slides for .NET.
// The example loads a PPTX file, calculates pixel dimensions based on the
// slide size, renders the slide to an image, and saves it as a PNG file.
// It also shows basic error handling for missing files and unsupported formats.
//
// Keywords:
// C#, Aspose.Slides, PPTX, PNG, 300 DPI, slide export, PowerPoint, .NET,
// Image rendering, Presentation processing
//
// Use Cases:
// - Convert PowerPoint slides to high‑resolution PNG images for publishing.
// - Automate batch export of slides at 300 DPI in C# tools.
// - Integrate slide rendering into .NET applications or services.
// - Validate slide appearance after programmatic modifications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "slide1.png";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Calculate pixel dimensions for 300 DPI based on slide size (points to inches conversion)
                    float widthPoints = presentation.SlideSize.Size.Width;
                    float heightPoints = presentation.SlideSize.Size.Height;
                    int widthPixels = (int)(widthPoints / 72f * 300f);
                    int heightPixels = (int)(heightPoints / 72f * 300f);
                    Size imageSize = new Size(widthPixels, heightPixels);

                    // Export the first slide as PNG with the calculated size
                    ISlide slide = presentation.Slides[0];
                    using (IImage image = slide.GetImage(imageSize))
                    {
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
