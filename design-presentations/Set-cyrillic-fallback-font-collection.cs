using System;
using System.IO;
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

            // Define Russian fonts for Cyrillic Unicode block (U+0400 to U+04FF)
            string[] russianFonts = new string[] { "Arial", "Times New Roman", "Calibri" };
            rules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, russianFonts));

            // Assign the rules collection to the presentation's FontsManager
            presentation.FontsManager.FontFallBackRulesCollection = rules;

            // Save the presentation
            try
            {
                presentation.Save("CyrillicFallback.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}