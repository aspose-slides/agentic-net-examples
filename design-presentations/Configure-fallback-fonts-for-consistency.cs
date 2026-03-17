using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Retrieve the existing fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

            // Add a fallback rule for a specific Unicode range
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

            // Assign the updated collection back to the FontsManager (optional if collection is mutable)
            presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

            // Configure save options with a default regular font
            Aspose.Slides.Export.PptOptions saveOptions = new Aspose.Slides.Export.PptOptions();
            saveOptions.DefaultRegularFont = "Arial";

            // Save the presentation with the specified options
            presentation.Save("FallbackFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}