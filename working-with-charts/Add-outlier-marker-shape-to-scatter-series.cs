// -----------------------------------------------------------------------------
// Example: Add outlier marker shape to scatter series using C#
//
// Description:
// Demonstrates how to add custom outlier marker shapes to a scatter chart series 
// using C# and Aspose.Slides for .NET. The example creates a presentation, adds a 
// scatter chart with smooth lines, populates two series with data points, and 
// highlights specific outlier points by setting their marker style and size. 
// It then saves the presentation as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Scatter Chart, Outlier Marker, 
// Custom Marker Shape, Chart Series, Presentation Automation
//
// Use Cases:
// - Highlight outlier data points in scatter charts programmatically.
// - Generate PowerPoint presentations with customized chart markers.
// - Automate chart styling for data analysis reports.
// - Integrate chart customization into .NET applications.
// -----------------------------------------------------------------------------
using System;
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
            string outputPath = "CustomMarkerScatterChart.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a scatter chart with smooth lines
                IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

                // Access the chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear any default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add two series
                chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

                // Get references to the series
                IChartSeries series1 = chart.ChartData.Series[0];
                IChartSeries series2 = chart.ChartData.Series[1];

                // Add data points to Series 1
                IChartDataPoint point1 = series1.DataPoints.AddDataPointForScatterSeries(1.0, workbook.GetCell(0, 1, 1, 2.0));
                IChartDataPoint point2 = series1.DataPoints.AddDataPointForScatterSeries(2.0, workbook.GetCell(0, 2, 1, 4.5));
                IChartDataPoint point3 = series1.DataPoints.AddDataPointForScatterSeries(3.0, workbook.GetCell(0, 3, 1, 3.0));

                // Highlight outlier point (e.g., point2) with a custom marker shape
                point2.Marker.Symbol = MarkerStyleType.Star;
                point2.Marker.Size = 15;

                // Add data points to Series 2
                IChartDataPoint point4 = series2.DataPoints.AddDataPointForScatterSeries(1.5, workbook.GetCell(0, 1, 2, 1.5));
                IChartDataPoint point5 = series2.DataPoints.AddDataPointForScatterSeries(2.5, workbook.GetCell(0, 2, 2, 2.0));
                IChartDataPoint point6 = series2.DataPoints.AddDataPointForScatterSeries(3.5, workbook.GetCell(0, 3, 2, 5.0));

                // Highlight outlier point (e.g., point6) with a custom marker shape
                point6.Marker.Symbol = MarkerStyleType.Diamond;
                point6.Marker.Size = 15;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                // Handle missing file scenario (if any external files were used)
                Console.WriteLine("Required file not found: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported format scenario
                // Format not supported
                Console.WriteLine("Operation not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
