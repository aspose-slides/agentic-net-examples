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
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);

        // Add text to the shape
        shape.AddTextFrame("Click here");

        // Set an external hyperlink that opens when the shape is clicked
        try
        {
            shape.HyperlinkManager.SetExternalHyperlinkClick("https://www.example.com");
        }
        catch (Exception ex)
        {
            // Handle any exception that occurs while setting the hyperlink
            Console.WriteLine("Error setting hyperlink: " + ex.Message);
        }

        // Save the presentation
        try
        {
            presentation.Save("HyperlinkDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other save errors
            // Format not supported
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Dispose the presentation object
        presentation.Dispose();
    }
}