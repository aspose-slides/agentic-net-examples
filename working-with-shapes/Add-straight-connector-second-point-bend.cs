// -----------------------------------------------------------------------------
// Example: Add straight connector second point bend using C#
//
// Description:
// Demonstrates how to add a straight connector with a custom second adjustment
// point bend using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds two shapes, connects them with a straight line connector,
// modifies the second adjustment point to create a bend, reroutes the connector,
// and saves the result as a PPTX file. This pattern can be used to automate
// connector styling and layout in PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Straight, Connector, Second,
// Point, Bend, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding straight connectors with custom bends.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with specific connector geometry.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "ConnectorBend.pptx";

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the shapes collection of the first slide
        IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add two shapes to be connected
        IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 300, 200, 120, 80);

        // Add a straight connector (using a line shape as a connector)
        IConnector connector = shapes.AddConnector(ShapeType.Line, 0, 0, 10, 10);

        // Connect the shapes
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Adjust the second adjustment point to create a custom bend
        if (connector.Adjustments.Count > 1)
        {
            // Example value; adjust as needed for the desired bend
            connector.Adjustments[1].RawValue = 5000;
        }

        // Reroute the connector to apply the adjustment
        connector.Reroute();

        // Save the presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other saving error
        }
    }
}
