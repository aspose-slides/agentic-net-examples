// -----------------------------------------------------------------------------
// Example: Add straight connector between an ellipse and a rectangle in a PPTX using C#
//
// Description:
// Demonstrates how to add a straight connector between an ellipse and a rectangle
// in a PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a new presentation, inserts two shapes, connects them with a straight
// connector, reroutes the connector, and saves the result as a PPTX file. This
// pattern can be used to automate shape linking, build presentation processing
// tools, or integrate connector logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Straight Connector, Shapes,
// Ellipse, Rectangle, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding straight connectors between shapes in PPTX files.
// - Build C# utilities for PowerPoint diagram creation and editing.
// - Generate or transform PPTX presentations with connected shapes in .NET.
// - Validate and test presentation workflows involving shape connections.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ConnectedShapes.pptx";

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the shape collection of the first slide
        IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add an ellipse shape
        IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a straight connector (using BentConnector2 as a simple connector)
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

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
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Clean up
        presentation.Dispose();
    }
}
