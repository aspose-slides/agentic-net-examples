using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the shape collection of the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add an ellipse shape
        Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a bent connector (used as a curved connector)
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the start of the connector to the ellipse
        connector.StartShapeConnectedTo = ellipse;

        // Connect the end of the connector to the rectangle
        connector.EndShapeConnectedTo = rectangle;

        // Set the end connection site to the fifth site (index 4) if available
        uint wantedIndex = 4;
        if (rectangle.ConnectionSiteCount > (int)wantedIndex)
        {
            connector.EndShapeConnectionSiteIndex = wantedIndex;
        }

        // Reroute the connector to take the shortest path
        connector.Reroute();

        // Save the presentation
        presentation.Save("CurvedConnectorDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}