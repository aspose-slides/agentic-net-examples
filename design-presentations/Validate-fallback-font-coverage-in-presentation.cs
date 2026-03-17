using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Initialize a new fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();

            // Add a fallback rule for the Basic Latin Unicode block (0x0020-0x007F) using Arial
            Aspose.Slides.IFontFallBackRule latinRule = new Aspose.Slides.FontFallBackRule(0x0020, 0x007F, "Arial");
            fallbackRules.Add(latinRule);

            // Add a fallback rule for the Cyrillic Unicode block (0x0400-0x04FF) using Times New Roman
            Aspose.Slides.IFontFallBackRule cyrillicRule = new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Times New Roman");
            fallbackRules.Add(cyrillicRule);

            // Assign the fallback rules collection to the presentation's FontsManager
            presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

            // Save the presentation to a PPTX file
            string outputPath = "FallbackFontPresentation.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}