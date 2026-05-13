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