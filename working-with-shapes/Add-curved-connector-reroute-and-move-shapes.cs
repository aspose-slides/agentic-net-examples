// -----------------------------------------------------------------------------
// Example: Add curved connector reroute and move shapes using C#
//
// Description:
// Demonstrates how to add a bent (curved) connector between two shapes, 
// reroute it to obtain the shortest path, move a shape to change the connector 
// routing, and reroute again using Aspose.Slides for .NET. The example creates 
// a new presentation, adds an ellipse and a rectangle, connects them, and 
// saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bent Connector, Curved Connector, 
// Reroute, Move Shapes, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding and rerouting curved connectors between shapes.
// - Build tools that adjust shape positions and update connector paths.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate connector routing logic in presentation workflows.
// -----------------------------------------------------------------------------

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

        // Add a bent connector (used as a curved connector)
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Reroute to get the shortest path
        connector.Reroute();

        // Move the rectangle to a new position to observe path change
        rectangle.X = 300;
        rectangle.Y = 350;

        // Reroute again after moving the shape
        connector.Reroute();

        // Save the presentation
        string outputPath = "CurvedConnectorDemo.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other saving issue
        }
    }
}
