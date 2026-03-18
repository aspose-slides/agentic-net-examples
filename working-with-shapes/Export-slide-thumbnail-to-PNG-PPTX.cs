using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            var outputFolder = "output";
            System.IO.Directory.CreateDirectory(outputFolder);
            using (var presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                for (var i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    using (var image = slide.GetImage())
                    {
                        var outputPath = System.IO.Path.Combine(outputFolder, $"slide_{i}.png");
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }
                }
                presentation.Save("saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}