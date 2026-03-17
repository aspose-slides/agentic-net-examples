using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            autoShape.AddTextFrame("Sample text with fallback fonts.");

            var fontsManager = presentation.FontsManager;
            var fallbackRules = fontsManager.FontFallBackRulesCollection;
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Arial"));

            presentation.Save("FallbackFontsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}