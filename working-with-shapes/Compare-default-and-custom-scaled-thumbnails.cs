// -----------------------------------------------------------------------------
// Example: Compare default and custom scaled thumbnails using C#
//
// Description:
// Demonstrates how to generate a default thumbnail and a custom‑scaled thumbnail
// from a PowerPoint slide using Aspose.Slides for .NET. The example loads a
// presentation, extracts the first slide, creates a default thumbnail (the
// library's built‑in scaling), then creates a thumbnail with user‑defined
// dimensions, and saves both images to disk. It also saves the original
// presentation unchanged.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Thumbnail, Default scaling,
// Custom scaling, Image generation, Presentation processing
//
// Use Cases:
// - Generate quick previews of slides with default scaling.
// - Produce high‑resolution thumbnails with custom dimensions.
// - Compare visual differences between default and custom thumbnail sizes.
// - Integrate thumbnail generation into automated PPTX workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string defaultThumbnailPath = "default_thumbnail.jpg";
            string customThumbnailPath = "custom_thumbnail.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Generate default thumbnail (20% size)
                using (IImage defaultImage = slide.GetImage())
                {
                    defaultImage.Save(defaultThumbnailPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Define desired dimensions for custom scaling
                int desiredX = 1200;
                int desiredY = 800;

                // Calculate scaling factors based on slide size
                float scaleX = (float)(1.0 / presentation.SlideSize.Size.Width) * desiredX;
                float scaleY = (float)(1.0 / presentation.SlideSize.Size.Height) * desiredY;

                // Generate custom‑scaled thumbnail
                using (IImage customImage = slide.GetImage(scaleX, scaleY))
                {
                    customImage.Save(customThumbnailPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save the presentation (required before exit)
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
