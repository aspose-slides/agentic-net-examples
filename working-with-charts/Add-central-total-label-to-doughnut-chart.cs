// -----------------------------------------------------------------------------
// Example: Add central total label to doughnut chart using C#
//
// Description:
// Demonstrates how to add a central total label to a doughnut chart using C#
// and Aspose.Slides for .NET. The example creates a new presentation, inserts a
// doughnut chart, populates it with data, calculates the total of the series,
// and displays the total in the chart’s central area via the chart title.
// This pattern can be used to automate PPTX workflows, validate results, or
// integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Central, Total, Label,
// Doughnut, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a central total label to a doughnut chart.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a doughnut chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Doughnut, 50, 50, 400, 400);

            // Set the doughnut hole size (percentage of plot area)
            chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = 50; // 50%

            // Prepare chart data
            Aspose.Slides.Charts.IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories
            chart.ChartData.Categories.Add(wb.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(wb.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(wb.GetCell(0, 3, 0, "Category 3"));

            // Add series and data points
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                wb.GetCell(0, 0, 1, "Series 1"), chart.Type);
            series.DataPoints.AddDataPointForDoughnutSeries(wb.GetCell(0, 1, 1, 30));
            series.DataPoints.AddDataPointForDoughnutSeries(wb.GetCell(0, 2, 1, 50));
            series.DataPoints.AddDataPointForDoughnutSeries(wb.GetCell(0, 3, 1, 20));

            // Calculate total sum of values
            double total = 30 + 50 + 20;

            // Add a central label using the chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Total: " + total);
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

            // Save the presentation
            pres.Save("DoughnutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, file I/O errors)
        }
    }
}
