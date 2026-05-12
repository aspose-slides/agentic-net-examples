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

        Aspose.Slides.Presentation pres = null;
        try
        {
            if (File.Exists(inputPath))
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            else
            {
                pres = new Aspose.Slides.Presentation();
            }

            // Define a fallback rule for a Unicode range with primary font "Arial"
            Aspose.Slides.IFontFallBackRule fallbackRule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Arial");
            // Add two alternative fallback fonts
            fallbackRule.AddFallBackFonts("Calibri");
            fallbackRule.AddFallBackFonts("Times New Roman");

            // Create a collection and add the rule
            Aspose.Slides.IFontFallBackRulesCollection rulesCollection = new Aspose.Slides.FontFallBackRulesCollection();
            rulesCollection.Add(fallbackRule);

            // Apply the fallback rules to the presentation
            pres.FontsManager.FontFallBackRulesCollection = rulesCollection;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, file access issues)
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}