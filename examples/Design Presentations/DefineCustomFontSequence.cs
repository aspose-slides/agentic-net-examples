using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape to the slide
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100) as Aspose.Slides.IAutoShape;

            // Add a text frame with sample text
            Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("Sample text with custom font fallback");

            // Set a font that does not exist to trigger fallback
            Aspose.Slides.IPortion portion = textFrame.Paragraphs[0].Portions[0];
            portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("NonExistentFont");

            // Define a fallback rule for a Unicode range (e.g., Cyrillic) to use Times New Roman
            Aspose.Slides.IFontFallBackRulesCollection fallbackRules = new Aspose.Slides.FontFallBackRulesCollection();
            fallbackRules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

            // Apply the fallback rules to the presentation
            presentation.FontsManager.FontFallBackRulesCollection = fallbackRules;

            // Save the presentation before exiting
            presentation.Save("CustomFontFallback.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}