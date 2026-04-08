using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputImagePath = "slide1.jpg";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            ISlide slide = presentation.Slides[0];
            IImage image = slide.GetImage(1f, 1f);
            image.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg, 80);
            // Save presentation before exit
            presentation.Save(inputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}