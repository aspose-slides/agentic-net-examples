using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the fallback rules collection from the FontsManager
            Aspose.Slides.IFontFallBackRulesCollection rules = presentation.FontsManager.FontFallBackRulesCollection;

            // Create a fallback rule for a Unicode range and specify the fallback font
            Aspose.Slides.IFontFallBackRule fallbackRule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman");

            // Add the rule to the collection
            rules.Add(fallbackRule);

            // Save the presentation
            presentation.Save("FallbackFont.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}