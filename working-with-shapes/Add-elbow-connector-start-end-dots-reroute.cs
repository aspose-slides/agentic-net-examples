// -----------------------------------------------------------------------------
// Example: Add elbow connector start end dots reroute using C#
//
// Description:
// Demonstrates how to add an elbow (bent) connector between an ellipse and a
// rectangle, set connection sites (dots), reroute the connector to the shortest
// path, and save the result using Aspose.Slides for .NET. The example shows the
// required presentation-processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use this
// pattern to automate PPTX workflows, validate results, or integrate presentation
// logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Elbow Connector, BentConnector,
// Connection Sites, Reroute, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding elbow connectors with start/end connection sites.
// - Build C# tools for PowerPoint shape linking and routing.
// - Generate or transform PPTX files with custom connectors in .NET applications.
// - Validate connector routing before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConnectShapesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the shape collection of the first slide
            Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add an ellipse shape
            Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);

            // Add a rectangle shape
            Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 300, 100, 100);

            // Add a bent connector (elbow connector)
            Aspose.Slides.IConnector connector = shapes.AddConnector(
                Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

            // Connect the shapes
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;

            // Specify connection sites (dots) if available
            if (ellipse.ConnectionSiteCount > 0)
            {
                connector.StartShapeConnectionSiteIndex = 0;
            }
            if (rectangle.ConnectionSiteCount > 0)
            {
                connector.EndShapeConnectionSiteIndex = 0;
            }

            // Reroute to the shortest path
            connector.Reroute();

            // Save the presentation
            string outputPath = "ConnectedShapes.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}
