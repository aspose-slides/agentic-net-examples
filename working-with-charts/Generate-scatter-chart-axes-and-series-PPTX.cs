using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a scatter chart with smooth lines
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
        int defaultWorksheetIndex = 0;

        // Clear default series
        chart.ChartData.Series.Clear();

        // Add two series
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
        chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

        // First series
        Aspose.Slides.Charts.IChartSeries series1 = chart.ChartData.Series[0];
        series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 1), workbook.GetCell(defaultWorksheetIndex, 2, 2, 3));
        series1.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 2), workbook.GetCell(defaultWorksheetIndex, 3, 2, 10));
        series1.Type = Aspose.Slides.Charts.ChartType.ScatterWithStraightLinesAndMarkers;
        series1.Marker.Size = 10;
        series1.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Star;

        // Second series
        Aspose.Slides.Charts.IChartSeries series2 = chart.ChartData.Series[1];
        series2.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 2, 3, 5), workbook.GetCell(defaultWorksheetIndex, 2, 4, 2));
        series2.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 3, 3, 3), workbook.GetCell(defaultWorksheetIndex, 3, 4, 1));
        series2.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 4, 3, 2), workbook.GetCell(defaultWorksheetIndex, 4, 4, 2));
        series2.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(defaultWorksheetIndex, 5, 3, 5), workbook.GetCell(defaultWorksheetIndex, 5, 4, 1));
        series2.Marker.Size = 10;
        series2.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;

        // Save the presentation
        presentation.Save("ScatterChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}