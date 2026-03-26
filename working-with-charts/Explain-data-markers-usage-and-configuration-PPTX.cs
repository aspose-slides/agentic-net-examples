using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation.
        using (Presentation presentation = new Presentation())
        {
            // Access the first slide.
            ISlide slide = presentation.Slides[0];

            // Add a line chart with markers.
            IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

            // Index of the default worksheet.
            int defaultWorksheetIndex = 0;
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove the automatically generated series and categories.
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories.
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Category 2"));
            chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Category 3"));

            // Add a series.
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);

            // Add data points to the series.
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 10));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 20));
            series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 15));

            // Configure the series marker (applies to all points unless overridden).
            IMarker seriesMarker = series.Marker;
            seriesMarker.Size = 10; // Marker size in points.
            seriesMarker.Symbol = MarkerStyleType.Circle; // Marker shape.

            // Override marker for the second data point.
            IChartDataPoint secondPoint = series.DataPoints[1];
            IMarker pointMarker = secondPoint.Marker;
            pointMarker.Size = 15;
            pointMarker.Symbol = MarkerStyleType.Diamond;

            // Save the presentation.
            presentation.Save("DataMarkersDemo.pptx", SaveFormat.Pptx);
        }
    }
}