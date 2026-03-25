using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderMathToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Set fallback font rules to preserve equation rendering
                Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
                fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    Aspose.Slides.IImage slideImage = presentation.Slides[index].GetImage(2f, 2f);
                    string outputPath = Path.Combine(outputDirectory, "slide_" + index + ".png");
                    slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }

                // Save the presentation before exiting
                presentation.Save("rendered_output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}