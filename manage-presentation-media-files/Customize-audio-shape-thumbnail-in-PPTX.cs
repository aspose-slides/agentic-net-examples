using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";
            var imagePath = "custom.jpg";

            using var presentation = new Aspose.Slides.Presentation(inputPath);
            var slide = presentation.Slides[0];

            var audioFrame = slide.Shapes.FirstOrDefault(s => s is Aspose.Slides.AudioFrame) as Aspose.Slides.AudioFrame;
            if (audioFrame != null)
            {
                using var imgStream = File.OpenRead(imagePath);
                var img = presentation.Images.AddImage(imgStream);
                audioFrame.PictureFormat.Picture.Image = img;
            }

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}