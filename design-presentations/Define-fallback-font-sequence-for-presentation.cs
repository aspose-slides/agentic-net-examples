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
            Presentation presentation = new Presentation();

            // Get the font fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = presentation.FontsManager.FontFallBackRulesCollection;

            // Add a fallback rule: for Unicode range 0x400-0x4FF use "Times New Roman"
            Aspose.Slides.FontFallBackRule rule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman");
            rules.Add(rule);

            // Save the presentation
            presentation.Save("FontFallback_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}