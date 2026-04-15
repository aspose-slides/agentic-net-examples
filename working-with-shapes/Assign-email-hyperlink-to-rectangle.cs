using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

        // Add a text frame with display text
        shape.AddTextFrame("Click to email");

        // Set an email hyperlink with a predefined subject line
        IHyperlinkManager hyperlinkManager = shape.HyperlinkManager;
        hyperlinkManager.SetExternalHyperlinkClick("mailto:example@example.com?subject=Test%20Subject");

        // Save the presentation
        presentation.Save("EmailHyperlink.pptx", SaveFormat.Pptx);
    }
}