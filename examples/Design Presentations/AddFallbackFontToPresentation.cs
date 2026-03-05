using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the folder containing the custom font file(s)
        string fontsFolderPath = "C:\\Fonts";

        // Path where the presentation will be saved
        string outputPresentationPath = "output.pptx";

        // Load custom fonts from the specified folder
        Aspose.Slides.FontsLoader.LoadExternalFonts(new string[] { fontsFolderPath });

        // Create a new empty presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Create a fallback rule for a Unicode range (e.g., 0x400-0x4FF) using the custom font name
        Aspose.Slides.IFontFallBackRule fallbackRule = new Aspose.Slides.FontFallBackRule(0x400u, 0x4FFu, "CustomFont");

        // Create a collection of fallback rules and add the rule to it
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
        fallbackRules.Add(fallbackRule);

        // Assign the fallback rules collection to the presentation's FontsManager
        presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

        // Save the presentation
        presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clear the loaded custom fonts from cache (optional cleanup)
        Aspose.Slides.FontsLoader.ClearCache();

        // Dispose the presentation object
        presentation.Dispose();
    }
}