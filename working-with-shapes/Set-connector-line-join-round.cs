// -----------------------------------------------------------------------------
// Example: Set connector line join round using C#
//
// Description:
// Demonstrates how to set the line join style to Round for connector shapes
// using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds sample shapes, connects them with bent connectors, applies the Round
// join style to all connectors, and saves the result as a PPTX file.
// This pattern can be used to customize connector appearance in automated
// PowerPoint processing scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Line, Join, Round,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting connector line join style to Round.
// - Build C# tools for customizing PowerPoint connector visuals.
// - Generate or transform PPTX files with specific connector formatting.
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
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add sample shapes
        IShapeCollection shapes = slide.Shapes;
        IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
        IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 200, 300, 100, 100);

        // Add connectors between shapes
        IConnector connector1 = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
        connector1.StartShapeConnectedTo = ellipse;
        connector1.EndShapeConnectedTo = rectangle;
        connector1.Reroute();

        IConnector connector2 = shapes.AddConnector(ShapeType.BentConnector2, 150, 150, 10, 10);
        connector2.StartShapeConnectedTo = ellipse;
        connector2.EndShapeConnectedTo = rectangle;
        connector2.Reroute();

        // Set line join style to Round for all connectors
        for (int i = 0; i < shapes.Count; i++)
        {
            IShape shape = shapes[i];
            if (shape is IConnector)
            {
                IConnector connector = (IConnector)shape;
                connector.LineFormat.JoinStyle = LineJoinStyle.Round;
            }
        }

        // Save the presentation
        string outputPath = "ConnectorsRoundJoinStyle.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}
