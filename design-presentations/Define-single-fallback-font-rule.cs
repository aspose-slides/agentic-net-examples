using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Create a new fallback rules collection
        Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

        // Add a rule for Cyrillic characters with fallback font "Arial"
        rules.Add(new Aspose.Slides.FontFallBackRule(0x0400u, 0x04FFu, "Arial"));

        // Add a rule for Emoji characters with fallback font "Segoe UI Emoji"
        rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600u, 0x1F64Fu, "Segoe UI Emoji"));

        // Assign the collection to the presentation's FontsManager
        presentation.FontsManager.FontFallBackRulesCollection = rules;

        // Save the presentation
        presentation.Save("FontFallbackDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}