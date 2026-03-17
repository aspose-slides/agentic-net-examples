using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var presentation = new Aspose.Slides.Presentation(inputPath);
            for (var i = 0; i < presentation.Slides.Count; i++)
            {
                var slide = presentation.Slides[i];
                var outputSvg = $"slide_{i + 1}.svg";
                using (var stream = File.Create(outputSvg))
                {
                    slide.WriteAsSvg(stream);
                }
            }
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}