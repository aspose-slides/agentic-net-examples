// -----------------------------------------------------------------------------
// Example: Rotate 3D chart view to angle using C#
//
// Description:
// Demonstrates how to rotate a 3‑D chart view to a specific angle using C# and
// Aspose.Slides for .NET. The example creates a presentation, adds a 3‑D
// clustered column chart, sets elevation and rotation angles, and saves the
// result as a PPTX file. Developers can use this pattern to automate PPTX
// workflows, validate results, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rotate, Chart, 3D, View, Angle,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate rotation of 3‑D chart views to specific angles.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized chart orientations.
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
        var outputPath = "Rotated3DChart.pptx";
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Add a 3‑D clustered column chart
            var chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn3D, 50, 50, 500, 400) as Aspose.Slides.Charts.IChart;

            if (chart != null)
            {
                // Set elevation (X rotation) and rotation (Y rotation)
                chart.Rotation3D.RotationX = 30; // Elevation angle
                chart.Rotation3D.RotationY = 45; // Rotation angle
                chart.Rotation3D.RightAngleAxes = false; // Use perspective
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
        }
    }
}
