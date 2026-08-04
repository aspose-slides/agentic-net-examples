// -----------------------------------------------------------------------------
// Example: Set bubble chart size range using C#
//
// Description:
// Demonstrates how to set the bubble size scaling factor for a bubble chart 
// using Aspose.Slides for .NET. The example creates a new presentation, adds a 
// bubble chart, populates it with X, Y, and size values, and adjusts the visual 
// size range of the bubbles by setting the BubbleSizeScale property.
//
// Keywords:
// C#, Aspose.Slides, Bubble Chart, BubbleSizeScale, Chart Size Range, PPTX, 
// Presentation Automation, .NET
//
// Use Cases:
// - Adjust visual bubble size range in generated PowerPoint charts.
// - Automate creation of bubble charts with custom scaling in .NET apps.
// - Generate PPTX reports that require specific bubble size representation.
// - Integrate bubble chart scaling into presentation processing pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "BubbleChartSizeRange.pptx";

            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a bubble chart with sample data
                    IChart chart = slide.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.Bubble,
                        50f, 50f, 500f, 400f);

                    // Access the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add a new series
                    IChartSeries series = chart.ChartData.Series.Add(
                        workbook.GetCell(0, 0, 1, "Series 1"),
                        chart.Type);

                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                    // Populate series with bubble data points (X, Y, Size)
                    series.DataPoints.AddDataPointForBubbleSeries(10.0, workbook.GetCell(0, 1, 1, 20.0), workbook.GetCell(0, 1, 2, 30.0));
                    series.DataPoints.AddDataPointForBubbleSeries(20.0, workbook.GetCell(0, 2, 1, 40.0), workbook.GetCell(0, 2, 2, 60.0));
                    series.DataPoints.AddDataPointForBubbleSeries(30.0, workbook.GetCell(0, 3, 1, 60.0), workbook.GetCell(0, 3, 2, 90.0));

                    // Set bubble size scaling factor (e.g., 150% of default)
                    // This influences the visual size range of bubbles
                    series.ParentSeriesGroup.BubbleSizeScale = 150;

                    // Save the presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (FileNotFoundException ex)
            {
                // Handle missing input file scenario (not used here)
                Console.WriteLine("Input file not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., unsupported format, library errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
