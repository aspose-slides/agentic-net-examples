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
            // Define input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Scaling factor of three for high‑resolution thumbnails
                int scaleX = 3;
                int scaleY = scaleX;

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Export each slide as a high‑resolution JPEG thumbnail
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    using (Aspose.Slides.IImage thumbnail = slide.GetImage(scaleX, scaleY))
                    {
                        string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
                        thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
                    }
                }

                // Save the presentation before exiting (no modifications made)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}