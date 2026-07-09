using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the shapes collection for the first slide
        IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add an ellipse shape
        IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

        // Add a bent connector shape
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the shapes using the connector
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Assign the start connection site to the second site (index 1) if available
        uint wantedIndex = 1;
        if (ellipse.ConnectionSiteCount > wantedIndex)
        {
            connector.StartShapeConnectionSiteIndex = wantedIndex;
        }

        // Do not call Reroute to disable automatic rerouting

        // Save the presentation
        string outputPath = "ConnectorExample.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other error handling
        }

        // Clean up
        presentation.Dispose();
    }
}