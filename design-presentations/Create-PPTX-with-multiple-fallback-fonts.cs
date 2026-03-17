using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape that will contain text
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
            Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("Sample text with fallback fonts.");

            // Define fallback font rules
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = presentation.FontsManager.FontFallBackRulesCollection;
            // Unicode range 0x0400-0x04FF (Cyrillic) fallback to Times New Roman
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x0400, 0x04FF, "Times New Roman"));
            // Unicode range 0x0500-0x05FF (Cyrillic Supplement) fallback to Arial
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x0500, 0x05FF, "Arial"));

            // Save the presentation
            presentation.Save("FallbackFontsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}