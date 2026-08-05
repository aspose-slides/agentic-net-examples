// -----------------------------------------------------------------------------
// Example: Add custom marker shape to scatter series using C#
//
// Description:
// Demonstrates how to add a custom marker shape to a scatter series in a PowerPoint
// presentation using Aspose.Slides for .NET. The example creates a scatter chart,
// adds data points including an outlier, sets a default marker style for the series,
// and highlights the outlier with a larger star-shaped marker. The resulting PPTX
// file can be used to visualize data with emphasized points.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Scatter Chart, Custom Marker,
// Marker Style, Outlier Highlight, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the creation of scatter charts with custom markers in PowerPoint.
// - Build .NET tools that emphasize specific data points (e.g., outliers) in presentations.
// - Generate or modify PPTX files programmatically for reporting or analytics.
// - Validate chart rendering and marker customization before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a scatter chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear any default series
            chart.ChartData.Series.Clear();

            // Add a new series
            chart.ChartData.Series.Add(workbook.GetCell(0, 0, 0, "Series 1"), chart.Type);
            IChartSeries series = chart.ChartData.Series[0];

            // Add data points (including an outlier)
            IChartDataPoint point1 = series.DataPoints.AddDataPointForScatterSeries(1.0, 2.0);
            IChartDataPoint point2 = series.DataPoints.AddDataPointForScatterSeries(2.0, 3.5);
            IChartDataPoint point3 = series.DataPoints.AddDataPointForScatterSeries(3.0, 2.5);
            IChartDataPoint outlier = series.DataPoints.AddDataPointForScatterSeries(4.0, 8.0); // Outlier point

            // Set default marker style for the series
            series.Marker.Size = 10;
            series.Marker.Symbol = MarkerStyleType.Circle;

            // Highlight the outlier with a custom marker shape
            outlier.Marker.Size = 15;
            outlier.Marker.Symbol = MarkerStyleType.Star;

            // Save the presentation
            string outputPath = "ScatterChartWithOutlier.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (System.IO.FileNotFoundException ex)
        {
            // Handle missing file errors (if any external files were used)
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions, such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
