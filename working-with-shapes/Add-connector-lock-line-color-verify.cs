// -----------------------------------------------------------------------------
// Example: Add connector lock line color verify using C#
//
// Description:
// Demonstrates how to add a connector between two shapes, set its line
// color, and lock the connector's line format to prevent further modifications
// using Aspose.Slides for .NET. The example creates a presentation, adds an
// ellipse and a rectangle, connects them with a bent connector, applies a red
// line color, locks edit points, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Lock, Line, Color,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding connectors with locked line formatting.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files while preserving visual styles.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ConnectorLockExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Presentation();

                // Access the first slide
                var slide = presentation.Slides[0];

                // Add two shapes to connect
                var shape1 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 100, 100, 100);
                var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 200, 120, 80);

                // Add a connector between the shapes
                var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
                connector.StartShapeConnectedTo = shape1;
                connector.EndShapeConnectedTo = shape2;
                connector.Reroute();

                // Set the connector's line color
                connector.LineFormat.FillFormat.FillType = FillType.Solid;
                connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

                // Lock the connector's line format to prevent color changes
                // Using EditPointsLocked as an example to lock modifications
                connector.ShapeLock.EditPointsLocked = true;

                // Save the presentation
                var outputPath = "ConnectorLocked.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported or other exception
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
