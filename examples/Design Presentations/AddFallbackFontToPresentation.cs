using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new empty presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Retrieve the collection of fallback font rules from the presentation's FontsManager
        Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

        // Define a fallback rule for Unicode range 0x400-0x4FF using "Times New Roman" as the fallback font
        Aspose.Slides.IFontFallBackRule fallbackRule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman");

        // Add the newly created rule to the collection
        fallbackRules.Add(fallbackRule);

        // Save the presentation to a file
        presentation.Save("FallbackFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}