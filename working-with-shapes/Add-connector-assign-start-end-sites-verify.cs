using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the shapes collection of the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add an ellipse shape
        Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a bent connector
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the shapes
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Assign custom connection sites if available
        uint startSiteIndex = 0;
        if (ellipse.ConnectionSiteCount > (int)startSiteIndex)
        {
            connector.StartShapeConnectionSiteIndex = startSiteIndex;
        }

        uint endSiteIndex = 1;
        if (rectangle.ConnectionSiteCount > (int)endSiteIndex)
        {
            connector.EndShapeConnectionSiteIndex = endSiteIndex;
        }

        // Reroute the connector to the shortest path
        connector.Reroute();

        // Verify alignment (example: alignment logic could be added here)

        // Save the presentation
        presentation.Save("ConnectorExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}