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

            // Access the shape collection of the first slide
            Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add a rectangle shape
            Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                150,   // X position
                150,   // Y position
                200,   // Width
                100);  // Height

            // Add a text frame to the rectangle
            rectangle.AddTextFrame("Click here");

            // Set an external hyperlink on the rectangle using HyperlinkManager
            Aspose.Slides.IHyperlinkManager hyperlinkManager = rectangle.HyperlinkManager;
            hyperlinkManager.SetExternalHyperlinkClick("https://www.example.com");

            // Save the presentation
            presentation.Save("RectangleHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}