using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ChartMarkerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line chart with markers
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.LineWithMarkers, 0, 0, 500, 400);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add a series
            chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Add categories and data points
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 10));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 20));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, 15));

            // Customize series marker
            series.Marker.Size = 10;
            series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Star;

            // Customize individual data point markers
            Aspose.Slides.Charts.IChartDataPoint point1 = series.DataPoints[0];
            point1.Marker.Size = 12;
            point1.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;

            Aspose.Slides.Charts.IChartDataPoint point2 = series.DataPoints[1];
            point2.Marker.Size = 14;
            point2.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Diamond;

            // Save the presentation
            presentation.Save("ChartMarkerDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}