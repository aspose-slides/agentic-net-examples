using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FallbackFontDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the fonts manager
                IFontsManager fontsManager = presentation.FontsManager;

                // Get the existing fallback rules collection
                IFontFallBackRulesCollection fallbackRules = fontsManager.FontFallBackRulesCollection;

                // Add a fallback rule for Unicode range 0x400-0x4FF using "Times New Roman"
                fallbackRules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                // Optionally replace the collection back (not required if the same instance is used)
                fontsManager.FontFallBackRulesCollection = fallbackRules;

                // Save the presentation
                presentation.Save("FallbackFontPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}