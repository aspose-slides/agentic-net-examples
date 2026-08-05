// -----------------------------------------------------------------------------
// Example: Add quadratic trendline to scatter forward two using C#
//
// Description:
// Demonstrates how to add a quadratic (polynomial order 2) trendline to a
// scatter chart with smooth lines and extend it forward by two category units
// using C# and Aspose.Slides for .NET. The example creates a new presentation,
// inserts a scatter chart, populates it with data points, applies the trendline,
// and saves the result as a PPTX file. This pattern can be used to automate
// chart enhancements in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Quadratic, Trendline, Scatter,
// Forward, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding quadratic trendlines to scatter charts in PowerPoint.
// - Build C# tools for enhancing chart data visualizations.
// - Generate or modify PPTX files with custom trendline settings.
// - Validate chart processing workflows before publishing or integration.
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
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a scatter chart with smooth lines
        IChart chart = slide.Shapes.AddChart(
            ChartType.ScatterWithSmoothLines,
            0, 0, 400, 400);

        // Get the chart data workbook
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add a series to the chart
        chart.ChartData.Series.Add(workbook.GetCell(0, 1, 1, "Series 1"), chart.Type);
        IChartSeries series = chart.ChartData.Series[0];

        // Populate the series with scatter data points (X, Y)
        series.DataPoints.AddDataPointForScatterSeries(
            workbook.GetCell(0, 2, 1, 1), workbook.GetCell(0, 2, 2, 2));
        series.DataPoints.AddDataPointForScatterSeries(
            workbook.GetCell(0, 3, 1, 2), workbook.GetCell(0, 3, 2, 4));
        series.DataPoints.AddDataPointForScatterSeries(
            workbook.GetCell(0, 4, 1, 3), workbook.GetCell(0, 4, 2, 6));

        // Add a quadratic (polynomial) trend line to the series
        ITrendline trendline = series.TrendLines.Add(
            TrendlineType.Polynomial);
        trendline.Order = 2;      // Quadratic
        trendline.Forward = 2;    // Extend forward by two category units

        // Save the presentation
        presentation.Save("ScatterChartWithQuadraticTrendline.pptx", SaveFormat.Pptx);
    }
}
