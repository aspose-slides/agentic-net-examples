// -----------------------------------------------------------------------------
// Example: Add connector start second site disable reroute using C#
//
// Description:
// Demonstrates how to add a bent connector whose start point is attached to the
// second connection site of an ellipse shape while disabling automatic rerouting,
// using C# and Aspose.Slides for .NET. The example creates a presentation, adds
// shapes, configures the connector, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Start, Second, Site,
// Reroute, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding connectors with specific connection sites and no reroute.
// - Build C# tools for precise PowerPoint diagram manipulation.
// - Generate or transform PPTX files in .NET applications.
// - Validate connector configurations before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the shape collection of the first slide
            IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add an ellipse shape
            IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);

            // Add a rectangle shape
            IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 100, 100);

            // Add a bent connector
            IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

            // Connect the start of the connector to the ellipse
            connector.StartShapeConnectedTo = ellipse;

            // Ensure the ellipse has at least two connection sites
            if (ellipse.ConnectionSiteCount > 1)
            {
                // Set the start connection site index to the second site (index 1)
                connector.StartShapeConnectionSiteIndex = 1;
            }

            // (Reroute is intentionally not called to disable automatic rerouting)

            // Save the presentation
            try
            {
                presentation.Save("ConnectedShapes.pptx", SaveFormat.Pptx);
            }
            catch (System.NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}
