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

            // Add a scatter chart with smooth lines
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add two series to the chart
            chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

            // First series data points with custom markers
            IChartSeries series1 = chart.ChartData.Series[0];
            IChartDataPoint point1 = series1.DataPoints.AddDataPointForScatterSeries(1.0, 2.0);
            point1.Marker.Size = 10;
            point1.Marker.Symbol = MarkerStyleType.Circle;

            IChartDataPoint point2 = series1.DataPoints.AddDataPointForScatterSeries(2.0, 3.5);
            point2.Marker.Size = 12;
            point2.Marker.Symbol = MarkerStyleType.Diamond;

            // Second series data points with custom markers
            IChartSeries series2 = chart.ChartData.Series[1];
            IChartDataPoint point3 = series2.DataPoints.AddDataPointForScatterSeries(1.5, 1.0);
            point3.Marker.Size = 8;
            point3.Marker.Symbol = MarkerStyleType.Square;

            IChartDataPoint point4 = series2.DataPoints.AddDataPointForScatterSeries(3.0, 4.0);
            point4.Marker.Size = 14;
            point4.Marker.Symbol = MarkerStyleType.Star;

            // Save the presentation
            presentation.Save("ScatterMarkers.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}