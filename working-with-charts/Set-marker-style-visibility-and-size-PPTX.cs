using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartMarkerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "ChartMarkerOptions.pptx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a Line chart with markers
            IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add a series
            chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            IChartSeries series = chart.ChartData.Series[0];

            // Add categories
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Category 4"));

            // Add data points for the series
            IChartDataPoint point1 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 10));
            IChartDataPoint point2 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 20));
            IChartDataPoint point3 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, 30));
            IChartDataPoint point4 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, 40));

            // Customize marker style and size for the whole series
            series.Marker.Size = 12; // Size in points
            series.Marker.Symbol = MarkerStyleType.Circle;

            // Hide marker for the third data point
            point3.Marker.Symbol = MarkerStyleType.None;

            // Change marker size for the fourth data point
            point4.Marker.Size = 20;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}