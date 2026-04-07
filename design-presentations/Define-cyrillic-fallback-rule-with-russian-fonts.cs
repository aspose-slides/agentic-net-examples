using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Initialize a new fallback rules collection
            Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

            // Add fallback rule for Cyrillic block with a single Russian font
            rules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Arial"));

            // Add another rule with a different Russian font
            rules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Times New Roman"));

            // Add a rule with multiple Russian fonts
            string[] russianFonts = new string[] { "Arial", "Times New Roman", "Calibri" };
            rules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, russianFonts));

            // Assign the rules collection to the presentation's FontsManager
            presentation.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation
            presentation.Save("CyrillicFallback.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}