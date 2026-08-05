// -----------------------------------------------------------------------------
// Example: Set connector dashdot verify pattern using C#
//
// Description:
// Demonstrates how to set a connector's dash‑dot line style and verify the
// effective dash style using Aspose.Slides for .NET. The example creates a
// presentation, adds shapes, connects them with a bent connector, applies a
// DashDot line style, retrieves the effective line format, and saves the
// result. This pattern helps developers automate PowerPoint connector styling
// and validation in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Connector, DashDot, Verify,
// LineFormat, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting and verifying connector dash‑dot line styles.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Validate visual styling of connectors in generated PPTX files.
// - Integrate line‑format verification into presentation workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var shapes = presentation.Slides[0].Shapes;

            var ellipse = shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 0, 100, 100, 100);
            var rectangle = shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 300, 100, 100);
            var connector = shapes.AddConnector(Aspose.Slides.ShapeType.BentConnector2, 0, 0, 10, 10);

            connector.StartShapeConnectedTo = ellipse;
            connector.EndShapeConnectedTo = rectangle;
            connector.Reroute();

            connector.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;

            var effective = connector.LineFormat.GetEffective();
            Console.WriteLine("Effective DashStyle: " + effective.DashStyle);

            string outputPath = "ConnectorDashDot.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
