using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the fallback rules collection from the FontsManager
        Aspose.Slides.IFontFallBackRulesCollection rules = pres.FontsManager.FontFallBackRulesCollection;

        // Create a new fallback rule for Unicode range 0x400-0x4FF with primary fallback font
        Aspose.Slides.IFontFallBackRule rule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman");

        // Add additional fallback fonts to the rule
        rule.AddFallBackFonts("Arial");
        rule.AddFallBackFonts(new string[] { "Calibri", "Helvetica" });

        // Add the rule to the collection
        rules.Add(rule);

        // Save the presentation
        pres.Save("FallbackFonts.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}