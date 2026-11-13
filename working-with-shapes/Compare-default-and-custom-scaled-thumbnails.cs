// -----------------------------------------------------------------------------
// Example: Compare default and custom scaled thumbnails using C#
// 
// Description:
// Demonstrates how to generate a default thumbnail and a custom‑scaled thumbnail
// from a PowerPoint slide using Aspose.Slides for .NET. The program creates a
// sample presentation if none exists, extracts the first slide, saves a default
// sized preview and a higher‑resolution preview, and writes the original file
// unchanged.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Thumbnail, Default scaling, Custom scaling, Image generation
// 
// Use Cases:
// - Generate quick previews of slides with default scaling.
// - Produce high‑resolution thumbnails with custom dimensions.
// - Compare visual differences between default and custom thumbnail sizes.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing.Imaging;

namespace ThumbnailComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string defaultThumbnailPath = "default_thumbnail.jpg";
            string customThumbnailPath = "custom_thumbnail.jpg";

            try
            {
                // Ensure input presentation exists; create a simple one if missing.
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation createPres = new Aspose.Slides.Presentation();
                    createPres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    createPres.Dispose();
                }

                // Load presentation.
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide.
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

                // Generate default thumbnail (scale factor 1).
                int defaultScaleX = 1;
                int defaultScaleY = 1;
                using (Aspose.Slides.IImage defaultImage = firstSlide.GetImage(defaultScaleX, defaultScaleY))
                {
                    defaultImage.Save(defaultThumbnailPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Generate custom‑scaled thumbnail (scale factor 2 for higher resolution).
                int customScaleX = 2;
                int customScaleY = 2;
                using (Aspose.Slides.IImage customImage = firstSlide.GetImage(customScaleX, customScaleY))
                {
                    customImage.Save(customThumbnailPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save the original presentation unchanged.
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported.
                Console.WriteLine("The presentation format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors).
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
