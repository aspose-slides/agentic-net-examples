using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Retrieve the existing fallback rules collection from the FontsManager
        Aspose.Slides.IFontFallBackRulesCollection rules = pres.FontsManager.FontFallBackRulesCollection;

        // Create a new fallback rule for a specific Unicode range (Cyrillic block) with a primary font
        Aspose.Slides.IFontFallBackRule rule = new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Arial");

        // Add additional fallback fonts to the rule
        rule.AddFallBackFonts("Times New Roman");
        rule.AddFallBackFonts(new string[] { "Calibri", "Verdana" });

        // Add the configured rule to the collection
        rules.Add(rule);

        // Assign the modified collection back to the FontsManager (optional if the same instance)
        pres.FontsManager.FontFallBackRulesCollection = rules;

        // Save the presentation before exiting
        pres.Save("FallbackFontsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}