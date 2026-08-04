// -----------------------------------------------------------------------------
// Example: Insert doughnut chart with series inner radius using C#
//
// Description:
// Demonstrates how to insert a doughnut chart and set its inner radius (doughnut
// hole size) using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds a doughnut chart with two series, defines categories and
// data points, configures the doughnut hole size, and saves the result as a PPTX
// file. This pattern can be used to automate chart creation with custom inner
// radius settings in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Doughnut, Chart,
// Series, Inner Radius, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of doughnut charts with a specific inner radius.
// - Build C# tools for PowerPoint presentation processing that require custom
//   chart styling.
// - Generate or transform PPTX files with doughnut charts in .NET applications.
// - Validate chart appearance and layout before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DoughnutChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a doughnut chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Doughnut,
                    50f, 50f, 500f, 400f);

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

                // Add first series and its data points
                Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                    chart.Type);
                series1.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 30));
                series1.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 40));
                series1.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));

                // Add second series and its data points
                Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series.Add(
                    workbook.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"),
                    chart.Type);
                series2.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 20));
                series2.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 30));
                series2.DataPoints.AddDataPointForDoughnutSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 50));

                // Set the doughnut hole size (percentage of plot area, e.g., 50%)
                chart.ChartData.Series[0].ParentSeriesGroup.DoughnutHoleSize = (byte)50;

                // Save the presentation
                string outputPath = "DoughnutChart.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
