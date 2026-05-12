using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPdfPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);

            // Create a fallback rule for Hangul Unicode range using "Malgun Gothic"
            IFontFallBackRule hangulRule = new FontFallBackRule(0xAC00u, 0xD7AFu, "Malgun Gothic");
            IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();
            rules.Add(hangulRule);
            pres.FontsManager.FontFallBackRulesCollection = rules;

            // Optionally save the presentation (required by lifecycle rule)
            pres.Save("intermediate.pptx", SaveFormat.Pptx);

            // Export to PDF
            pres.Save(outputPdfPath, SaveFormat.Pdf);

            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}