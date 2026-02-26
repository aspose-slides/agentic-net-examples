using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the existing fallback rules collection from the FontsManager
        IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

        // Create a new fallback rule for a Unicode range and a primary font
        FontFallBackRule rule = new FontFallBackRule(0x400, 0x4FF, "Times New Roman");

        // Add additional fallback fonts to the rule
        rule.AddFallBackFonts("Arial");
        rule.AddFallBackFonts(new string[] { "Calibri", "Verdana" });

        // Add the rule to the collection
        fallbackRules.Add(rule);

        // Save the presentation before exiting
        presentation.Save("FallbackFonts.pptx", SaveFormat.Pptx);
    }
}