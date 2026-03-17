using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Aspose.Slides.Presentation();

                // Retrieve the current fallback rules collection
                var fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

                // Add a custom fallback rule (e.g., for Cyrillic range)
                fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Arial"));

                // Assign the modified collection back to the FontsManager (optional)
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Save the presentation as PPTX
                presentation.Save("CustomFontFallback.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}