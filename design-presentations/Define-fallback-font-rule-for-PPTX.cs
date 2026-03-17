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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a slide based on the first layout
                Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a rectangle shape with text using a potentially missing font
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                autoShape.AddTextFrame("Sample text with missing font");
                autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new Aspose.Slides.FontData("NonExistentFont");

                // Configure a fallback font rule (use Arial when the original font is unavailable)
                Aspose.Slides.IFontsManager fontsManager = presentation.FontsManager;
                Aspose.Slides.IFontFallBackRulesCollection fallbackRules = fontsManager.FontFallBackRulesCollection;
                fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x0, 0xFFFF, "Arial"));

                // Save the presentation
                presentation.Save("FallbackFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}