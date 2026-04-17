using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "Thumbnails";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            float slideWidth = presentation.SlideSize.Size.Width;
            float slideHeight = presentation.SlideSize.Size.Height;

            foreach (ISlide slide in presentation.Slides)
            {
                float scaleX = 1f;
                float scaleY = 1f;

                // Validate that scaling does not exceed slide dimensions
                if (scaleX > 1f || scaleY > 1f)
                {
                    Console.WriteLine($"Scale exceeds slide dimensions for slide {slide.SlideNumber}");
                    continue;
                }

                IImage thumbnail = slide.GetImage(scaleX, scaleY);
                string outputPath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}.jpg");
                thumbnail.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                thumbnail.Dispose();
            }

            // Save presentation before exit
            presentation.Save("output.pptx", SaveFormat.Pptx);
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