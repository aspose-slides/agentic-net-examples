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
            // Input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";
            var defaultThumbPath = "default_thumb.jpg";
            var customThumbPath = "custom_thumb.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                var pres = new Presentation(inputPath);

                // Access the first slide
                var slide = pres.Slides[0];

                // Generate default thumbnail (20% size)
                using (var defaultImg = slide.GetImage())
                {
                    defaultImg.Save(defaultThumbPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Define custom dimensions for scaling
                var desiredX = 1200;
                var desiredY = 800;
                var scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
                var scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

                // Generate custom-scaled thumbnail
                using (var customImg = slide.GetImage(scaleX, scaleY))
                {
                    customImg.Save(customThumbPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save the presentation (no modifications, just to satisfy lifecycle rule)
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}