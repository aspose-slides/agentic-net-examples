// -----------------------------------------------------------------------------
// Example: Add curved connector 3pt line thickness using C#
//
// Description:
// Demonstrates how to add a curved connector with a 3‑point line thickness
// using C# and Aspose.Slides for .NET. The example creates a new presentation,
// adds an ellipse and a rectangle, connects them with a curved connector,
// sets the connector line width to three points, and saves the result as a
// PPTX file. This pattern can be used to automate PowerPoint shape linking and
// styling tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Curved, Connector, Line,
// Thickness, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding curved connectors with specific line thickness.
// - Build C# utilities for PowerPoint shape manipulation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate connector styling in presentation workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "CurvedConnector.pptx";
        try
        {
            Presentation presentation = new Presentation();
            IShapeCollection shapes = presentation.Slides[0].Shapes;

            // Add shapes to connect
            IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 50, 100, 100, 100);
            IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 300, 250, 100, 100);

            // Add a curved connector
            IConnector connector = shapes.AddConnector(ShapeType.CurvedConnector2, 0, 0, 10, 10);
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;
            connector.Reroute();

            // Set line width to three points (visual thickness verification via inspection)
            connector.LineFormat.Width = 3;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // General exception handling
        }
    }
}
