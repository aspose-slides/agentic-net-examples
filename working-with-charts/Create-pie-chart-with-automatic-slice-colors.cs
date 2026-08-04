// -----------------------------------------------------------------------------
// Example: Create pie chart with automatic slice colors using C#
//
// Description:
// Demonstrates how to create a pie chart with automatic slice colors using C#
// and Aspose.Slides for .NET. The example shows how to add a pie chart,
// define categories and series, enable varied slice colors, and save the
// presentation as a PPTX file in a standalone console application. Developers
// can use this pattern to automate PPTX workflows, validate results, or
// integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Pie, Automatic Slice Colors,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of pie charts with automatically varied slice colors.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
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
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        IChart chart = slide.Shapes.AddChart(
            ChartType.Pie, 50f, 50f, 500f, 400f);

        // Set chart title
        chart.ChartTitle.AddTextFrameForOverriding("Sample Pie Chart");
        chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
        chart.ChartTitle.Height = 20f;
        chart.HasTitle = true;

        // Show values on the chart
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Workbook for chart data
        int defaultWorksheetIndex = 0;
        IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

        // Add a series
        IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

        // Add data points for the series
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 50));
        series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 20));

        // Enable automatic slice colors
        series.ParentSeriesGroup.IsColorVaried = true;

        // Save the presentation
        presentation.Save("PieChart_AutomaticColors.pptx", SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}
