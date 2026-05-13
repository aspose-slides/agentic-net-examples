using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);

        // Add a text frame with display text
        shape.AddTextFrame("Contact Us");

        // Define the mailto hyperlink with a predefined subject line
        string mailto = "mailto:someone@example.com?subject=Inquiry";

        // Assign the hyperlink to the portion text
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink(mailto);

        // Save the presentation before exiting
        presentation.Save("EmailHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}