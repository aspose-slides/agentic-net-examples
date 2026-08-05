// -----------------------------------------------------------------------------
// Example: Set 3D chart view elevation and rotation using C#
//
// Description:
// Demonstrates how to create a 3‑D clustered column chart, configure its
// elevation (RotationX) and rotation (RotationY) angles, and save the result
// as a PPTX file using Aspose.Slides for .NET. The example shows the required
// presentation‑processing steps for PowerPoint files and can be used as a
// standalone console application. Developers can adapt this pattern to
// automate PPTX workflows, validate chart rendering, or integrate presentation
// logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, 3D, Elevation, Rotation,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting 3‑D chart view elevation and rotation.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized 3‑D charts in .NET
//   applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a 3‑D chart (ClusteredColumn supports 3‑D view)
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);

        // Configure 3‑D rotation
        chart.Rotation3D.RightAngleAxes = false; // enable perspective
        chart.Rotation3D.RotationX = 30; // elevation angle (Y‑axis rotation)
        chart.Rotation3D.RotationY = 45; // rotation angle (X‑axis rotation)

        // Save the presentation
        try
        {
            presentation.Save("3DChartRotation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Clean up
        presentation.Dispose();
    }
}
