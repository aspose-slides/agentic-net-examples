using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new empty presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the existing fallback rules collection from the FontsManager
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

            // Create a new fallback rule for Unicode range 0x0400-0x04FF with primary fallback font
            Aspose.Slides.IFontFallBackRule newRule = new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Times New Roman");

            // Add additional fallback fonts to the rule
            newRule.AddFallBackFonts("Arial");
            newRule.AddFallBackFonts(new string[] { "Tahoma", "Calibri" });

            // Add the rule to the collection
            fallbackRules.Add(newRule);

            // Assign the modified collection back to the FontsManager (optional if collection is mutable)
            presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

            // Save the presentation before exiting
            presentation.Save("FallbackFonts.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}