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
                using (Presentation presentation = new Presentation())
                {
                    // Get the fallback rules collection
                    IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;

                    // Add a fallback rule: for Unicode range 0x400-0x4FF use "Times New Roman"
                    fallbackRules.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

                    // Assign the modified collection back (optional, as collection is mutable)
                    presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                    // Save the presentation
                    presentation.Save("FallbackFontPresentation.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}