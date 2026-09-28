// -----------------------------------------------------------------------------
// Example: Enable Smooth Lines for Spline Chart Using Aspose.Slides
//
// Description:
// This console application creates a new PowerPoint presentation, adds a
// scatter chart configured with smooth lines (spline chart), populates it
// with sample data, and saves the result as a PPTX file. It demonstrates how
// to use Aspose.Slides for .NET to style charts with smooth line rendering.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, spline chart, smooth lines, scatter chart
//
// Use Cases:
// - Automating the creation of presentations with professionally styled spline charts.
// - Generating reports that require smooth line visualizations in PowerPoint.
// - Integrating chart styling into a larger document generation workflow.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesSmoothSplineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "SmoothSplineChart.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a scatter chart with smooth lines (spline chart)
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                    50,   // X position
                    50,   // Y position
                    500,  // Width
                    400   // Height
                );

                // Access the chart's workbook to add data
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear any default series or categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a series
                chart.ChartData.Series.Add(
                    workbook.GetCell(0, 1, 1, "Series 1"),
                    chart.Type
                );

                // Retrieve the newly added series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

                // Ensure the series type is set to smooth lines (optional, reinforces chart type)
                series.Type = Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines;

                // Add data points for the scatter series (X, Y)
                series.DataPoints.AddDataPointForScatterSeries(
                    workbook.GetCell(0, 2, 1, 1),   // X = 1
                    workbook.GetCell(0, 2, 2, 2)    // Y = 2
                );
                series.DataPoints.AddDataPointForScatterSeries(
                    workbook.GetCell(0, 3, 1, 2),   // X = 2
                    workbook.GetCell(0, 3, 2, 3)    // Y = 3
                );
                series.DataPoints.AddDataPointForScatterSeries(
                    workbook.GetCell(0, 4, 1, 3),   // X = 3
                    workbook.GetCell(0, 4, 2, 5)    // Y = 5
                );
                series.DataPoints.AddDataPointForScatterSeries(
                    workbook.GetCell(0, 5, 1, 4),   // X = 4
                    workbook.GetCell(0, 5, 2, 4)    // Y = 4
                );

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to " + Path.GetFullPath(outputPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
