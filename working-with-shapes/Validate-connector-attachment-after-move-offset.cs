using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the shape collection of the first slide
        Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;

        // Add an ellipse shape
        Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 300, 100, 100);

        // Add a bent connector
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the shapes using the connector
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;
        connector.Reroute();

        // Move the source shape (ellipse) by a specified offset
        float offsetX = 50f;
        float offsetY = 30f;
        ellipse.X += offsetX;
        ellipse.Y += offsetY;

        // Validate that the connector remains attached to the moved shape
        bool isAttached = Object.ReferenceEquals(connector.StartShapeConnectedTo, ellipse);
        Console.WriteLine("Connector attached to source shape after move: " + isAttached);

        // Save the presentation
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ConnectorMoveDemo.pptx");
        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other saving errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Dispose the presentation
        pres.Dispose();
    }
}