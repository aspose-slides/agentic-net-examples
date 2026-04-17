using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputDir = "output_images";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            float scaleX = 2f;
            float scaleY = 2f;

            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY);
                string outputPath = Path.Combine(outputDir, $"Slide_{i + 1}.jpg");
                image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                image.Dispose();
            }

            // Save presentation before exit
            string savedPath = "saved_output.pptx";
            presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
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