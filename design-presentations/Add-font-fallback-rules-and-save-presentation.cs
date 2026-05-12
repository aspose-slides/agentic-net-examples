using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Initialize a new FontFallBackRulesCollection
            IFontFallBackRulesCollection rules = new FontFallBackRulesCollection();

            // Add a rule for Unicode range 0x400-0x4FF with a single fallback font
            rules.Add(new FontFallBackRule(0x400u, 0x4FFu, "Times New Roman"));

            // Add a rule for Unicode range 0x1F600-0x1F64F with multiple fallback fonts
            string[] emojiFonts = new string[] { "Segoe UI Emoji", "Arial Unicode MS" };
            rules.Add(new FontFallBackRule(0x1F600u, 0x1F64Fu, emojiFonts));

            // Assign the collection to the presentation's FontsManager
            presentation.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation
            presentation.Save("FontFallbackOutput.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}