using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Create a collection for font fallback rules
        Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

        // Add a fallback rule for Cyrillic characters (U+0400 to U+04FF) using Times New Roman
        rules.Add(new Aspose.Slides.FontFallBackRule(0x400u, 0x4FFu, "Times New Roman"));

        // Add a fallback rule for Hiragana characters (U+3040 to U+309F) using MS Mincho
        rules.Add(new Aspose.Slides.FontFallBackRule(0x3040u, 0x309Fu, "MS Mincho"));

        // Add a fallback rule for emoji characters (U+1F600 to U+1F64F) with multiple fonts
        string[] emojiFonts = new string[] { "Segoe UI Emoji", "Apple Color Emoji", "Noto Color Emoji" };
        rules.Add(new Aspose.Slides.FontFallBackRule(0x1F600u, 0x1F64Fu, emojiFonts));

        // Assign the fallback rules collection to the presentation's FontsManager
        presentation.FontsManager.FontFallBackRulesCollection = rules;

        // Save the presentation to a file
        presentation.Save("FallbackFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}