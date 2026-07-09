using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ConnectorDemo.pptx";
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the shapes collection of the first slide
            IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add an ellipse shape
            IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

            // Add a rectangle shape
            IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

            // Add a straight connector
            IConnector connector = shapes.AddConnector(ShapeType.StraightConnector1, 0, 0, 10, 10);

            // Connect the connector to the first connection site of each shape
            connector.StartShapeConnectedTo = ellipse;
            connector.StartShapeConnectionSiteIndex = 0;
            connector.EndShapeConnectedTo = rectangle;
            connector.EndShapeConnectionSiteIndex = 0;

            // Reroute the connector to compute the shortest path
            connector.Reroute();

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}