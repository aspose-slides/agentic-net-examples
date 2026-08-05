// -----------------------------------------------------------------------------
// Example: Add connector set dashdotdot verify using C#
//
// Description:
// Demonstrates how to add an ellipse and a rectangle shape, connect them with a
// bent connector, set the connector line dash style to dash‑dot‑dot, reroute
// the connector to the shortest path, and save the presentation using
// Aspose.Slides for .NET. The example verifies the visual result by saving the
// file for manual inspection.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Dashdotdot, Verify,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding connectors with dash‑dot‑dot style between shapes.
// - Build C# tools for PowerPoint presentation processing and visual verification.
// - Generate or transform PPTX files with custom connector formatting in .NET applications.
// - Validate connector routing and styling before publishing or integration.
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
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

        // Add a bent connector
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the shapes using the connector
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Set the connector line dash style to dash‑dot‑dot
        connector.LineFormat.DashStyle = LineDashStyle.LargeDashDotDot;

        // Reroute the connector to the shortest path
        connector.Reroute();

        // Save the presentation (verify appearance by opening the file)
        string outputPath = "ConnectorDashDotDot.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}
