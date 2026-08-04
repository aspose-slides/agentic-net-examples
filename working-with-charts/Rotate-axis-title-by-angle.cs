// -----------------------------------------------------------------------------
// Example: Rotate axis title by angle using C#
//
// Description:
// Demonstrates how to rotate the vertical and horizontal axis titles of a chart
// by specific angles using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds a clustered column chart, enables axis titles, sets
// rotation angles, and saves the result as a PPTX file. This pattern can be used
// to customize chart appearance programmatically.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rotate, Axis, Title, Angle, Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically rotate chart axis titles for better layout.
// - Build C# tools that customize chart formatting in PowerPoint files.
// - Generate or modify PPTX presentations with specific axis title orientations.
// - Automate presentation styling tasks before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "RotatedAxisTitle.pptx";
        try
        {
            Presentation presentation = new Presentation();
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
            chart.Axes.VerticalAxis.HasTitle = true;
            chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 45f;
            chart.Axes.HorizontalAxis.HasTitle = true;
            chart.Axes.HorizontalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = -30f;
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            // Format not supported
        }
    }
}
