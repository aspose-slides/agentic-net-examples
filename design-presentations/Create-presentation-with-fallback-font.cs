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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a rectangle shape with a text frame
                Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                shape.AddTextFrame("Sample text with Unicode characters: 漢字");

                // Create a fallback rules collection
                Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();

                // Add a fallback rule for the Unicode range 0x0400-0x04FF (Cyrillic) to use Times New Roman
                fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Times New Roman"));

                // Assign the fallback rules to the presentation's FontsManager
                presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

                // Save the presentation as PPTX
                presentation.Save("FallbackFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}