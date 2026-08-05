// -----------------------------------------------------------------------------
// Example: Validate connector attachment after move using C#
//
// Description:
// Demonstrates how to validate that a connector remains attached to a shape
// after the shape is moved using C# and Aspose.Slides for .NET. The example
// creates a presentation, adds an ellipse and a rectangle, connects them with
// a bent connector, moves the ellipse, and verifies the connector's attachment.
// It also saves the presentation and handles potential save errors.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Connector,
// Attachment, After, Move, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validation of connector attachment after shape movement.
// - Build C# tools for PowerPoint presentation processing and verification.
// - Generate or transform PPTX files while ensuring diagram integrity.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the shape collection of the first slide
        Aspose.Slides.IShapeCollection shapes = pres.Slides[0].Shapes;

        // Add an ellipse and a rectangle
        Aspose.Slides.IAutoShape ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);
        Aspose.Slides.IAutoShape rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 300, 100, 100);

        // Add a bent connector and connect the shapes
        Aspose.Slides.IConnector connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);
        connector.StartShapeConnectedTo = ellipse;
        connector.EndShapeConnectedTo = rectangle;
        connector.Reroute();

        // Move the source shape (ellipse) by a specified offset
        float offsetX = 50f;
        float offsetY = 30f;
        ellipse.X += offsetX;
        ellipse.Y += offsetY;

        // Validate that the connector remains attached to the moved shape
        bool isStillAttached = Object.ReferenceEquals(connector.StartShapeConnectedTo, ellipse);
        Console.WriteLine("Connector still attached after moving source shape: " + isStillAttached);

        // Save the presentation (handle unsupported format exception)
        string outPath = "ConnectorValidation.pptx";
        try
        {
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Format not supported or other save error
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Dispose the presentation
        pres.Dispose();
    }
}
