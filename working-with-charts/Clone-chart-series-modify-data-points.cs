// -----------------------------------------------------------------------------
// Example: Clone chart series modify data points using C#
//
// Description:
// Demonstrates how to create a clustered column chart, clear its default
// series and categories, add custom categories, add an original series with
// data points, clone the series by adding a second series with modified data
// points, and save the presentation using Aspose.Slides for .NET. This example
// can be used as a template for automating chart manipulation in PowerPoint
// files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone, Chart, Series, Modify,
// Data Points, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning and modifying chart series in PowerPoint presentations.
// - Build .NET tools for chart data manipulation and visualization.
// - Generate or transform PPTX files with custom chart data.
// - Validate chart-related workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add the first series and populate it with data points
            Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"),
                chart.Type);
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
            series1.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

            // Duplicate the series for comparative overlay
            Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 2, "Series 2"),
                chart.Type);
            // Modify data points (e.g., increase each value by 10)
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 30));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 60));
            series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 2, 40));

            // Save the presentation
            string outputPath = "DuplicatedSeries.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
