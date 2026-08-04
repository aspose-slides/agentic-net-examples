// -----------------------------------------------------------------------------
// Example: Add exact value labels to bubble chart using C#
//
// Description:
// Demonstrates how to create a bubble chart, populate it with data points, and
// enable data labels to show the exact values for each bubble using C# and
// Aspose.Slides for .NET. The example includes the necessary presentation‑processing
// steps for PowerPoint files and produces the output in a standalone console
// application. Developers can use this pattern to automate PPTX workflows,
// generate charts programmatically, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble Chart, Data Labels,
// Exact Values, Chart Automation, Office Automation
//
// Use Cases:
// - Automate creation of bubble charts with value labels in PowerPoint.
// - Build C# tools for generating and customizing chart data in presentations.
// - Generate visual reports that include bubble charts with precise data labels.
// - Validate and test chart data within PPTX files before publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddBubbleChartDataLabels
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a bubble chart to the slide
                IChart chart = slide.Shapes.AddChart(
                    ChartType.Bubble, 0, 0, 500, 400);

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Remove default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

                // Add categories (X axis labels)
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Populate series with bubble data points (X, Y, BubbleSize)
                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(0, 1, 1, 10),   // X value
                    workbook.GetCell(0, 1, 2, 20),   // Y value
                    workbook.GetCell(0, 1, 3, 30));  // Bubble size

                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(0, 2, 1, 15),
                    workbook.GetCell(0, 2, 2, 25),
                    workbook.GetCell(0, 2, 3, 35));

                series.DataPoints.AddDataPointForBubbleSeries(
                    workbook.GetCell(0, 3, 1, 20),
                    workbook.GetCell(0, 3, 2, 30),
                    workbook.GetCell(0, 3, 3, 40));

                // Enable data labels to show the exact value for each bubble
                series.Labels.DefaultDataLabelFormat.ShowValue = true;

                // Save the presentation
                pres.Save("BubbleChartWithLabels.pptx", SaveFormat.Pptx);
            }
        }
    }
}
