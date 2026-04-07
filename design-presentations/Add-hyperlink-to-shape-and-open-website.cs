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
            Aspose.Slides.ShapeType.Rectangle, 150, 150, 150, 50);
        shape.AddTextFrame("Click Here");

        // Set an external hyperlink that opens a website when the shape is clicked
        Aspose.Slides.IHyperlinkManager hyperlinkManager = shape.HyperlinkManager;
        hyperlinkManager.SetExternalHyperlinkClick("https://www.example.com");

        // Save the presentation (handle unsupported format exception)
        try
        {
            presentation.Save("HyperlinkShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose the presentation before exiting
        presentation.Dispose();
    }
}