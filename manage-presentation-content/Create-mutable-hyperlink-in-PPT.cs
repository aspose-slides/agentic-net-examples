using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MutableHyperlinkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle auto shape to the first slide
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                100, 100, 300, 50,
                false);

            // Add a text frame with initial text
            shape.AddTextFrame("Click here");

            // Set initial mutable hyperlink
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink("http://example.com");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Initial link";
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 14f;

            // Save the presentation with the initial hyperlink
            presentation.Save("MutableHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Update the hyperlink to a new URL and tooltip
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink("http://updated.com");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Updated link";

            // Save the presentation after updating the hyperlink
            presentation.Save("MutableHyperlink_Updated.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}