using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputSvgPath = "output.svg";
        string outputPptxPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);
            IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();
            // Arabic Unicode range 0x0600 - 0x06FF, fallback to an Arabic OpenType font (e.g., "Amiri")
            rules.Add(new FontFallBackRule(0x0600, 0x06FF, "Amiri"));
            pres.FontsManager.FontFallBackRulesCollection = rules;

            using (FileStream svgStream = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
            {
                pres.Slides[0].WriteAsSvg(svgStream);
            }

            // Save the presentation before exiting
            pres.Save(outputPptxPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}