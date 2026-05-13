using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ConnectedShapes.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the shape collection of the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add an ellipse shape
        Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a straight connector (using BentConnector2 as a simple connector)
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the connector to the first connection site of each shape, if available
        if (ellipse.ConnectionSiteCount > 0)
        {
            connector.StartShapeConnectedTo = ellipse;
            connector.StartShapeConnectionSiteIndex = 0;
        }

        if (rectangle.ConnectionSiteCount > 0)
        {
            connector.EndShapeConnectedTo = rectangle;
            connector.EndShapeConnectionSiteIndex = 0;
        }

        // Adjust the connector path
        connector.Reroute();

        // Save the presentation (handle unsupported format)
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Clean up
        presentation.Dispose();
    }
}