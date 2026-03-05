using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape to the slide
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

        // Add a TextFrame with sample text
        Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame("Sample text with custom font fallback.");

        // Create a font fallback rules collection
        Aspose.Slides.IFontFallBackRulesCollection rules = new Aspose.Slides.FontFallBackRulesCollection();

        // Add a fallback rule for Unicode range 0x400-0x4FF to use Times New Roman
        rules.Add(new Aspose.Slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

        // Assign the fallback rules to the presentation's FontsManager
        presentation.FontsManager.FontFallBackRulesCollection = rules;

        // Save the presentation
        presentation.Save("CustomFontFallbackPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}