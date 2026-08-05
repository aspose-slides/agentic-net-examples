// -----------------------------------------------------------------------------
// Example: Add elbow connector start third site lock using C#
//
// Description:
// Demonstrates how to add an elbow (bent) connector to a presentation, connect its
// start to an ellipse shape using the third connection site, lock the connector
// position, and save the result using Aspose.Slides for .NET. The example shows the
// required presentation-processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use this
// pattern to automate PPTX workflows, validate results, or integrate presentation
// logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Elbow Connector, BentConnector2,
// Start Shape Connection Site, Third Site, Connector Lock, Presentation Processing,
// Office Automation
//
// Use Cases:
// - Automate adding an elbow connector with a specific start connection site.
// - Build C# tools for PowerPoint presentation processing and shape linking.
// - Generate or transform PPTX files with locked connectors in .NET applications.
// - Validate connector routing and locking before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the shape collection of the first slide
        IShapeCollection shapes = pres.Slides[0].Shapes;

        // Add an ellipse shape
        IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

        // Add a rectangle shape
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

        // Add an elbow (bent) connector
        IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

        // Connect the start of the connector to the ellipse and set the third connection site
        connector.StartShapeConnectedTo = ellipse;
        uint thirdSiteIndex = 2;
        if (ellipse.ConnectionSiteCount > thirdSiteIndex)
        {
            connector.StartShapeConnectionSiteIndex = thirdSiteIndex;
        }

        // Connect the end of the connector to the rectangle
        connector.EndShapeConnectedTo = rectangle;

        // Lock the connector to prevent moving
        connector.ConnectorLock.PositionMove = true;

        // Reroute the connector to the shortest path
        connector.Reroute();

        // Save the presentation
        string outputPath = "ConnectedShapes.pptx";
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            pres.Dispose();
        }
    }
}
