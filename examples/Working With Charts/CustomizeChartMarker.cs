using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

namespace CustomizeChartMarker
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
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 500, 400);

            // Prepare chart data workbook
            int defaultWorksheetIndex = 0;
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a series
            chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Add first data point and customize its marker
            Aspose.Slides.Charts.IChartDataPoint point1 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            point1.Marker.Format.Fill.FillType = FillType.Solid;
            point1.Marker.Format.Fill.SolidFillColor.Color = Color.Blue;
            point1.Marker.Format.Line.FillFormat.FillType = FillType.Solid;
            point1.Marker.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;
            point1.Marker.Size = 12;
            point1.Marker.Symbol = MarkerStyleType.Circle;

            // Add second data point and customize its marker
            Aspose.Slides.Charts.IChartDataPoint point2 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            point2.Marker.Format.Fill.FillType = FillType.Solid;
            point2.Marker.Format.Fill.SolidFillColor.Color = Color.Green;
            point2.Marker.Format.Line.FillFormat.FillType = FillType.Solid;
            point2.Marker.Format.Line.FillFormat.SolidFillColor.Color = Color.DarkGray;
            point2.Marker.Size = 12;
            point2.Marker.Symbol = MarkerStyleType.Square;

            // Add third data point and customize its marker
            Aspose.Slides.Charts.IChartDataPoint point3 = series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 30));
            point3.Marker.Format.Fill.FillType = FillType.Solid;
            point3.Marker.Format.Fill.SolidFillColor.Color = Color.Red;
            point3.Marker.Format.Line.FillFormat.FillType = FillType.Solid;
            point3.Marker.Format.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
            point3.Marker.Size = 12;
            point3.Marker.Symbol = MarkerStyleType.Diamond;

            // Save the presentation
            presentation.Save("CustomizeMarker.pptx", SaveFormat.Pptx);
        }
    }
}