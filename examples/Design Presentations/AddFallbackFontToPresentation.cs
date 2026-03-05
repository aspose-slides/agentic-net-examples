using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the fallback rules collection from the FontsManager
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

        // Create a new fallback rule for Unicode range 0x400-0x4FF with fallback font "Times New Roman"
        Aspose.Slides.IFontFallBackRule fallbackRule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman");

        // Add the rule to the collection
        fallbackRules.Add(fallbackRule);

        // Save the presentation
        presentation.Save("FallbackFontPresentation.pptx", SaveFormat.Pptx);
    }
}