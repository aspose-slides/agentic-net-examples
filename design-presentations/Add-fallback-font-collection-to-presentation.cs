using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Retrieve the fallback rules collection
                Aspose.Slides.IFontFallBackRulesCollection rules = presentation.FontsManager.FontFallBackRulesCollection;

                // Add a fallback rule for Unicode range 0x400-0x4FF to use Times New Roman
                Aspose.Slides.FontFallBackRule rule = new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman");
                rules.Add(rule);

                // Save the presentation before exiting
                presentation.Save("FallbackFontPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}