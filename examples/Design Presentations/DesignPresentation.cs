using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the fonts manager
        Aspose.Slides.IFontsManager fontsManager = presentation.FontsManager;

        // Get the fallback rules collection
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = fontsManager.FontFallBackRulesCollection;

        // Add a fallback rule for a Unicode range to use "Times New Roman"
        fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

        // Save the presentation
        presentation.Save("FallbackFontsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}