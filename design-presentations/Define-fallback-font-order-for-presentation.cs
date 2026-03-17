using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Access the font fallback rules collection
            var fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

            // Define custom fallback: Unicode range 0x400-0x4FF uses "Times New Roman"
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

            // Additional example rule: Unicode range 0x500-0x5FF uses "Arial"
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x500, 0x5FF, "Arial"));

            // Save the presentation before exiting
            presentation.Save("CustomFontFallback.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}