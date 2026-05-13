using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the shape collection of the first slide
        IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add an ellipse shape
        IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a bent connector (used as a curved connector)
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Reroute to get the shortest path
        connector.Reroute();

        // Move the rectangle to a new position to observe path change
        rectangle.X = 300;
        rectangle.Y = 350;

        // Reroute again after moving the shape
        connector.Reroute();

        // Save the presentation
        string outputPath = "CurvedConnectorDemo.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other saving issue
        }
    }
}