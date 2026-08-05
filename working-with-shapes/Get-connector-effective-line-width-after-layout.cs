// -----------------------------------------------------------------------------
// Example: Get connector effective line width after layout using C#
//
// Description:
// Demonstrates how to get connector effective line width after layout using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, Effective, Line, 
// Width, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate get connector effective line width after layout.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            // Output file path
            string outputPath = "ConnectorEffectiveLineWidth.pptx";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the shape collection of the first slide
            IShapeCollection shapes = pres.Slides[0].Shapes;

            // Add two shapes to connect
            IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0f, 100f, 100f, 100f);
            IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100f, 300f, 100f, 100f);

            // Add a connector shape
            IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0f, 0f, 10f, 10f);
            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;
            connector.Reroute();

            // Retrieve the effective line width after layout inheritance
            ILineFormatEffectiveData effectiveLineFormat = connector.LineFormat.GetEffective();
            double effectiveWidth = effectiveLineFormat.Width;
            Console.WriteLine("Effective line width: " + effectiveWidth);

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
