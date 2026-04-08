using System;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle shape with a text frame
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50, false);
            shape.AddTextFrame("Click here");

            // Set the initial hyperlink
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
                new Aspose.Slides.Hyperlink("http://example.com");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Initial link";

            // Modify the hyperlink URL by assigning a new Hyperlink object
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
                new Aspose.Slides.Hyperlink("https://newexample.org");
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "Updated link";

            // Save the presentation
            presentation.Save("MutableHyperlinkDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}