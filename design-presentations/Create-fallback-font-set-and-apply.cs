using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FontFallbackExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                var presentation = new Aspose.Slides.Presentation();

                // Get the existing fallback rules collection
                var fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

                // Add a new fallback rule (Unicode range 0x400-0x4FF maps to Times New Roman)
                fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                // Optionally replace the collection back (not required if modified in place)
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Save the presentation
                presentation.Save("FallbackFontsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}