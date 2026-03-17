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

            // Set default regular font for saving (fallback)
            Aspose.Slides.Export.PptOptions saveOptions = new Aspose.Slides.Export.PptOptions();
            saveOptions.DefaultRegularFont = "Arial";

            // Add a font fallback rule
            Aspose.Slides.IFontsManager fontsManager = presentation.FontsManager;
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = fontsManager.FontFallBackRulesCollection;
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

            // Save the presentation
            presentation.Save("FallbackFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}