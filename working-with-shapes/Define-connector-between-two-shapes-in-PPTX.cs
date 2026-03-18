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

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Access the shape collection
            Aspose.Slides.IShapeCollection shapes = slide.Shapes;

            // Add an ellipse shape
            Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0f, 100f, 100f, 100f);

            // Add a rectangle shape
            Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100f, 300f, 100f, 100f);

            // Add a bent connector shape
            Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0f, 0f, 10f, 10f);

            // Connect the shapes
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;

            // Reroute the connector to the shortest path
            connector.Reroute();

            // Save the presentation
            presentation.Save("ShapesConnector.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}