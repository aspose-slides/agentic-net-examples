using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle shape to the first slide
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 150, 150, 300, 50);

            // Add a text frame with display text
            shape.AddTextFrame("Visit Aspose");

            // Assign an external hyperlink to the text portion
            shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick =
                new Aspose.Slides.Hyperlink("https://www.aspose.com");

            // Save the presentation in PPTX format
            presentation.Save("HyperlinkRectangle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}