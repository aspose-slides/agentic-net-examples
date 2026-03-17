using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var pres = new Aspose.Slides.Presentation(inputPath))
            {
                var scaleX = 2f;
                var scaleY = 2f;

                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    var slide = pres.Slides[i];
                    using (var image = slide.GetImage(scaleX, scaleY))
                    {
                        var imagePath = $"slide_{i + 1}.png";
                        image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}