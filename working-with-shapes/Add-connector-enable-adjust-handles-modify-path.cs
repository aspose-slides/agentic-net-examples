// -----------------------------------------------------------------------------
// Example: Add connector enable adjust handles modify path using C#
//
// Description:
// Demonstrates how to add a bent connector between two shapes, unlock its
// adjustment handles, modify its adjustment values, reroute the connector and
// save the presentation using Aspose.Slides for .NET. The example shows the
// required presentation‑processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use
// this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Enable Adjust Handles,
// Modify Path, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a connector with unlocked adjustment handles.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate connector geometry and adjustments before publishing or integration.
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

        // Get the shape collection of the first slide
        IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add two shapes to be connected
        IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

        // Add a bent connector
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the shapes
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Enable adjustment handles (unlock them)
        connector.ShapeLock.AdjustHandlesLocked = false;

        // Modify adjustment values if they exist
        if (connector.Adjustments.Count > 0)
        {
            IAdjustValue firstAdjustment = connector.Adjustments[0];
            // Example modification: increase angle value
            firstAdjustment.AngleValue = firstAdjustment.AngleValue + 10;
        }

        if (connector.Adjustments.Count > 1)
        {
            IAdjustValue secondAdjustment = connector.Adjustments[1];
            // Example modification: decrease angle value
            secondAdjustment.AngleValue = secondAdjustment.AngleValue - 5;
        }

        // Reroute the connector to apply changes
        connector.Reroute();

        // Retrieve geometry paths to confirm the new shape (can be inspected if needed)
        IGeometryPath[] geometryPaths = connector.GetGeometryPaths();

        // Save the presentation
        try
        {
            presentation.Save("ConnectorAdjustments.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other save error
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
