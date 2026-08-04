// -----------------------------------------------------------------------------
// Example: Add multiline callout to bubble chart using C#
//
// Description:
// Demonstrates how to create a bubble chart, add data points, enable data
// label callouts, and set a multiline callout text for a bubble using
// Aspose.Slides for .NET. The example shows the required presentation-processing
// steps for PowerPoint files and saves the result as a PPTX file in a console
// application. Developers can use this pattern to automate chart annotation,
// generate presentations with custom callouts, or integrate chart logic into
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble Chart, Multiline Callout,
// Data Labels, Chart Automation, Presentation Processing, Office Automation
//
// Use Cases:
// - Add multiline callouts to specific bubbles in a chart.
// - Build C# tools for annotating charts in PowerPoint presentations.
// - Generate or modify PPTX files with custom chart data and labels.
// - Automate presentation workflows that require detailed bubble annotations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AddMultilineCalloutToBubbleChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a bubble chart
                IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50f, 50f, 500f, 400f);

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), ChartType.Bubble);

                // Add categories (required for bubble chart)
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                // Configure data source types to accept literal double values
                series.DataPoints.DataSourceTypeForXValues = DataSourceType.DoubleLiterals;
                series.DataPoints.DataSourceTypeForYValues = DataSourceType.DoubleLiterals;
                series.DataPoints.DataSourceTypeForBubbleSizes = DataSourceType.DoubleLiterals;

                // Add data points (X, Y, BubbleSize) using double literals
                IChartDataPoint dp1 = series.DataPoints.AddDataPointForBubbleSeries(1.0, 2.0, 3.0);
                IChartDataPoint dp2 = series.DataPoints.AddDataPointForBubbleSeries(2.0, 3.5, 4.0);
                IChartDataPoint dp3 = series.DataPoints.AddDataPointForBubbleSeries(3.0, 1.5, 2.5);

                // Enable callout for data labels in this series
                series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Add multiline callout text to the first bubble (dp1)
                dp1.Label.TextFrameForOverriding.Text = "First Bubble\nMultiline Callout";

                // Optionally customize the callout appearance (fill and line)
                // dp1.Format.Fill.FillType = FillType.Solid;
                // dp1.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Yellow;
                // dp1.Format.Line.FillFormat.FillType = FillType.Solid;
                // dp1.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

                // Save the presentation
                try
                {
                    pres.Save("BubbleChartWithCallout.pptx", SaveFormat.Pptx);
                }
                catch (ArgumentException ex)
                {
                    // Handle unsupported format exception
                    Console.WriteLine("Error: The specified format is not supported. " + ex.Message);
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., file I/O issues)
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }
        }
    }
}
