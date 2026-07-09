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

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            Presentation presentation = new Presentation(inputPath);
            foreach (ISlide slide in presentation.Slides)
            {
                float slideWidth = presentation.SlideSize.Size.Width;
                float scale = 200f / slideWidth;
                IImage thumbnail = slide.GetImage(scale, scale);
                string imagePath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}.jpg");
                thumbnail.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                thumbnail.Dispose();
            }

            // Save the presentation before exiting (no modifications made)
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