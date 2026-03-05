using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            int slideCount = presentation.Slides.Count;
            for (int i = 0; i < slideCount; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                string outputSvgPath = $"slide_{i + 1}.svg";
                using (Stream fileStream = File.Create(outputSvgPath))
                {
                    slide.WriteAsSvg(fileStream);
                }
            }

            string outputPresentationPath = "output.pptx";
            presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}