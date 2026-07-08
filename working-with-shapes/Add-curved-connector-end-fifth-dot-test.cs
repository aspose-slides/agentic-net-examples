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

        // Add a rectangle shape (will serve as the end shape)
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a curved connector (using BentConnector2 as an example)
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the start of the connector to the ellipse
        connector.StartShapeConnectedTo = ellipse;

        // Connect the end of the connector to the rectangle
        connector.EndShapeConnectedTo = rectangle;

        // Set the end connection site to the fifth site (index 4) if available
        if (rectangle.ConnectionSiteCount > 4)
        {
            connector.EndShapeConnectionSiteIndex = 4;
        }

        // Reroute the connector to take the shortest path
        connector.Reroute();

        // Save the presentation
        string outputPath = "CurvedConnectorDemo.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}