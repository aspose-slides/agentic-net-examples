using System;
using System.IO;
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
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a connector (using BentConnector2 as a curved connector)
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the shapes
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Enable reroute to calculate the shortest path
        connector.Reroute();

        // Move the rectangle to a new position to observe path changes
        rectangle.X = 300;
        rectangle.Y = 200;

        // Reroute again after moving the shape
        connector.Reroute();

        // Define output file path
        string outputPath = "CurvedConnectorDemo.pptx";

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputPath));
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}