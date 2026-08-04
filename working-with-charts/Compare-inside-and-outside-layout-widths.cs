// -----------------------------------------------------------------------------
// Example: Compare inside and outside layout widths of a chart using C#
//
// Description:
// Demonstrates how to compare the inner and outer layout widths of a chart's
// plot area using C# and Aspose.Slides for .NET. The example creates a
// presentation, adds a clustered column chart, sets manual layout bounds,
// measures the plot area width when the layout target is set to Inner and
// Outer, outputs the measurements, and saves the presentation. This pattern
// helps developers understand layout behavior and automate chart sizing in
// PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compare, Inside, Outside,
// Layout, Chart, PlotArea, Presentation Processing, Office Automation
//
// Use Cases:
// - Determine differences between inner and outer layout widths for charts.
// - Build C# tools that adjust chart sizing based on layout targets.
// - Automate validation of chart layout behavior in PPTX files.
// - Integrate chart layout analysis into .NET applications.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

            // Define manual layout for the plot area (same fractional bounds for both tests)
            chart.PlotArea.AsILayoutable.X = 0.1f;
            chart.PlotArea.AsILayoutable.Y = 0.1f;
            chart.PlotArea.AsILayoutable.Width = 0.8f;
            chart.PlotArea.AsILayoutable.Height = 0.8f;

            // Measure width with Inner layout target
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
            chart.ValidateChartLayout();
            float innerWidth = chart.PlotArea.ActualWidth;

            // Measure width with Outer layout target
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Outer;
            chart.ValidateChartLayout();
            float outerWidth = chart.PlotArea.ActualWidth;

            // Output the results
            Console.WriteLine("Inner layout plot area width: " + innerWidth);
            Console.WriteLine("Outer layout plot area width: " + outerWidth);

            // Save the presentation
            string outputPath = "LayoutComparison.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other exceptions
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
