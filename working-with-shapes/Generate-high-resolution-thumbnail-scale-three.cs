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
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Scaling factor of three for high‑resolution thumbnails
                int scaleX = 3;
                int scaleY = 3;

                // Export each slide as a high‑resolution JPEG thumbnail
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    using (Aspose.Slides.IImage thumbnail = slide.GetImage((float)scaleX, (float)scaleY))
                    {
                        string imageFileName = String.Format("Slide_{0}.jpg", slide.SlideNumber);
                        thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
                    }
                }

                // Save the (unchanged) presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}