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
            Presentation presentation = new Presentation();

            // Access the shape collection of the first slide
            IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add an ellipse shape
            IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

            // Add a rectangle shape
            IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

            // Add a straight connector (using BentConnector2 as a simple connector)
            IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

            // Connect the connector to the first connection site of each shape
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

            // Reroute the connector to ensure proper path
            connector.Reroute();

            // Save the presentation
            string outputPath = "ConnectedShapes.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}