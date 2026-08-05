// -----------------------------------------------------------------------------
// Example: Add connector assign start end sites verify using C#
//
// Description:
// Demonstrates how to add a bent connector between an ellipse and a rectangle,
// assign custom start and end connection sites, reroute the connector to the
// shortest path, and save the presentation using C# and Aspose.Slides for .NET.
// The example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Assign, Start,
// Sites, End, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a connector and assigning start/end connection sites.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate connector routing and alignment before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the shapes collection of the first slide
        Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

        // Add an ellipse shape
        Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 300, 100, 100);

        // Add a bent connector
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the shapes
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;

        // Assign custom connection sites if available
        uint startSiteIndex = 0;
        if (ellipse.ConnectionSiteCount > (int)startSiteIndex)
        {
            connector.StartShapeConnectionSiteIndex = startSiteIndex;
        }

        uint endSiteIndex = 1;
        if (rectangle.ConnectionSiteCount > (int)endSiteIndex)
        {
            connector.EndShapeConnectionSiteIndex = endSiteIndex;
        }

        // Reroute the connector to the shortest path
        connector.Reroute();

        // Verify alignment (example: alignment logic could be added here)

        // Save the presentation
        presentation.Save("ConnectorExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
