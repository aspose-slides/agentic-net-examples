// -----------------------------------------------------------------------------
// Example: Add curved connector end dot fifth site using C#
//
// Description:
// Demonstrates how to add a bent (curved) connector between an ellipse and a
// rectangle shape, set the connector's end connection site to the fifth site,
// reroute it for the shortest path, and save the presentation using Aspose.Slides
// for .NET. The example shows the required presentation-processing steps for
// PowerPoint files and produces the requested output in a standalone console
// application. Developers can use this pattern to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bent Connector, Curved Connector,
// Connection Site, Fifth Site, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a bent connector with a specific end connection site.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate connector routing and connection sites before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the shape collection of the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add an ellipse shape
        Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a bent connector (used as a curved connector)
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the start of the connector to the ellipse
        connector.StartShapeConnectedTo = ellipse;

        // Connect the end of the connector to the rectangle
        connector.EndShapeConnectedTo = rectangle;

        // Set the end connection site to the fifth site (index 4) if available
        uint wantedIndex = 4;
        if (rectangle.ConnectionSiteCount > (int)wantedIndex)
        {
            connector.EndShapeConnectionSiteIndex = wantedIndex;
        }

        // Reroute the connector to take the shortest path
        connector.Reroute();

        // Save the presentation
        presentation.Save("CurvedConnectorDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
