// -----------------------------------------------------------------------------
// Example: Add data labels to pie chart using C#
//
// Description:
// Demonstrates how to create a pie chart, populate it with data, and enable
// data labels (category name and value) using C# and Aspose.Slides for .NET.
// The example shows the required steps to build a presentation, add a chart,
// configure its data, turn on data labels, and save the result as a PPTX file.
// Developers can use this pattern to automate chart creation, enhance visual
// reporting, or integrate PowerPoint generation into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pie Chart, Data Labels, Chart,
// Presentation Generation, Office Automation
//
// Use Cases:
// - Automate creation of pie charts with visible data labels.
// - Build C# tools for generating PowerPoint reports with charts.
// - Integrate chart generation into .NET applications or services.
// - Produce presentations that include detailed chart annotations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddDataLabelsToPieChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output path for the generated presentation
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "AddDataLabelsToPieChart.pptx");

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Use the first (default) slide
                ISlide slide = pres.Slides[0];

                // Add a pie chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

                // Access the chart's workbook to set data
                IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

                // Clear any default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories (slice names)
                chart.ChartData.Categories.Add(wb.GetCell(0, 0, 1, "Category 1"));
                chart.ChartData.Categories.Add(wb.GetCell(0, 0, 2, "Category 2"));
                chart.ChartData.Categories.Add(wb.GetCell(0, 0, 3, "Category 3"));

                // Add a series and populate data points
                IChartSeries series = chart.ChartData.Series.Add(ChartType.Pie);
                series.DataPoints.AddDataPointForPieSeries(wb.GetCell(0, 1, 1, 30));
                series.DataPoints.AddDataPointForPieSeries(wb.GetCell(0, 1, 2, 20));
                series.DataPoints.AddDataPointForPieSeries(wb.GetCell(0, 1, 3, 50));

                // Enable data labels: show both category name and value
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
                series.Labels.DefaultDataLabelFormat.ShowValue = true;

                // Save the presentation to the specified file
                pres.Save(outputPath, SaveFormat.Pptx);
            }

            Console.WriteLine("Presentation saved to " + outputPath);
        }
    }
}
