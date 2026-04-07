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
            string inputPath = "input.pptx";
            string outputDirectory = "Thumbnails";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            try
            {
                Presentation presentation = new Presentation(inputPath);

                int desiredX = 200;
                int desiredY = 150;
                float scaleX = (float)(1.0 / presentation.SlideSize.Size.Width) * desiredX;
                float scaleY = (float)(1.0 / presentation.SlideSize.Size.Height) * desiredY;

                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    IImage image = slide.GetImage(scaleX, scaleY);
                    string outputPath = Path.Combine(outputDirectory, $"Slide_{index + 1}.jpg");
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save presentation before exit (no modifications made)
                presentation.Save(inputPath, SaveFormat.Pptx);
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