// -----------------------------------------------------------------------------
// Example: Resize plot area based on actual dimensions using C#
//
// Description:
// Demonstrates how to retrieve the actual dimensions of a chart's plot area,
// calculate custom dimensions, and resize the plot area accordingly using
// Aspose.Slides for .NET. The example creates a presentation, adds a clustered
// column chart, computes width and height fractions relative to the chart size,
// applies the new plot area size, and saves the result as a PPTX file. This
// pattern can be used to programmatically adjust chart layouts in PowerPoint
// files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Resize, Plot, Area, Actual,
// Dimensions, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Adjust chart plot area size based on specific dimension requirements.
// - Automate chart layout modifications in bulk PowerPoint files.
// - Build .NET tools for precise presentation formatting.
// - Validate and fine‑tune chart appearances before distribution.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.Chart chart = (Aspose.Slides.Charts.Chart)presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
        chart.ValidateChartLayout();

        // Get actual dimensions of the plot area
        double actualWidth = chart.PlotArea.ActualWidth;
        double actualHeight = chart.PlotArea.ActualHeight;

        // Desired custom dimensions (in points)
        double customWidth = 300.0;
        double customHeight = 200.0;

        // Compute fractions relative to the chart size
        float widthFraction = (float)(customWidth / chart.Width);
        float heightFraction = (float)(customHeight / chart.Height);

        // Set new plot area size using fractions
        chart.PlotArea.Width = widthFraction;
        chart.PlotArea.Height = heightFraction;

        // Save the presentation
        try
        {
            presentation.Save("ResizedPlotArea.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle unsupported format or other save errors
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
