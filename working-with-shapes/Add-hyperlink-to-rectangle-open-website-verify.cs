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
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 50);

        // Add a text frame with display text
        shape.AddTextFrame("Click here to visit Aspose");

        // Assign an external hyperlink to the text portion
        shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.aspose.com");

        // Save the presentation; handle unsupported format exception
        try
        {
            presentation.Save("HyperlinkDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Ensure the presentation is saved before exiting
        presentation.Dispose();
    }
}