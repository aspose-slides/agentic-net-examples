using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string imagePath = "slide1.png";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();
            rules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Times New Roman"));
            string[] emojiFonts = new string[] { "Segoe UI Emoji", "Noto Color Emoji" };
            rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600, 0x1F64F, emojiFonts));
            presentation.FontsManager.FontFallBackRulesCollection = rules;

            Aspose.Slides.IImage image = presentation.Slides[0].GetImage(1f, 1f);
            image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
            image.Dispose();

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // format not supported
            Console.WriteLine("File format not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}