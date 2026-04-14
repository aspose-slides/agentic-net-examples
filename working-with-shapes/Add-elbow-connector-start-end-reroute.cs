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

        // Add an elbow (bent) connector
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the shapes
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Specify connection site indices (use first site if available)
        if (ellipse.ConnectionSiteCount > 0)
        {
            connector.StartShapeConnectionSiteIndex = 0;
        }
        if (rectangle.ConnectionSiteCount > 0)
        {
            connector.EndShapeConnectionSiteIndex = 0;
        }

        // Reroute to the shortest path
        connector.Reroute();

        // Save the presentation
        presentation.Save("ElbowConnector.pptx", SaveFormat.Pptx);
    }
}