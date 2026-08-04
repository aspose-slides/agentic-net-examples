// -----------------------------------------------------------------------------
// Example: Add linear trendline with equation to a scatter chart using C#
//
// Description:
// Demonstrates how to create a PowerPoint presentation, add a scatter chart,
// populate it with data series, and attach a linear trendline that displays its
// equation using Aspose.Slides for .NET. The example runs as a standalone console
// application and saves the resulting PPTX file.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Scatter Chart, Trendline, Linear Trendline,
// Equation Display, Chart Data, Presentation Automation, Office Automation
//
// Use Cases:
// - Generate PowerPoint slides with scatter charts that include analytical trendlines.
// - Build C# utilities for adding statistical insights to presentations.
// - Automate creation of PPTX reports with chart annotations and equations.
// - Integrate chart trendline features into .NET applications for data visualization.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesTrendlineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "ScatterTrendline.pptx");

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a scatter chart
                IChart chart = slide.Shapes.AddChart(
                    ChartType.ScatterWithSmoothLines,
                    0f, 0f, 400f, 400f);

                // Get the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                int defaultWorksheetIndex = 0;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add two series
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
                chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

                // Add data points to the first series
                IChartSeries series1 = chart.ChartData.Series[0];
                series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 1.0), workbook.GetCell(defaultWorksheetIndex, 2, 2, 2.0));
                series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 2.0), workbook.GetCell(defaultWorksheetIndex, 3, 2, 3.5));
                series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 3.0), workbook.GetCell(defaultWorksheetIndex, 4, 2, 5.0));

                // Add a linear trendline to the first series and display its equation
                ITrendline trendline = series1.TrendLines.Add(TrendlineType.Linear);
                trendline.DisplayEquation = true;
                trendline.DisplayRSquaredValue = false;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, file I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
