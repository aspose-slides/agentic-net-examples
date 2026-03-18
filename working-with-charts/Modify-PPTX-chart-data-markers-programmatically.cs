using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a scatter chart with markers
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ScatterWithMarkers,
                    50, 50, 500, 400);

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add a new series
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"),
                    chart.Type);

                // Add data points (each will have a marker)
                Aspose.Slides.Charts.IChartDataPoint point1 = series.DataPoints.AddDataPointForScatterSeries(1.0, 2.0);
                Aspose.Slides.Charts.IChartDataPoint point2 = series.DataPoints.AddDataPointForScatterSeries(2.0, 3.5);
                Aspose.Slides.Charts.IChartDataPoint point3 = series.DataPoints.AddDataPointForScatterSeries(3.0, 1.5);

                // Set marker style for the first point
                Aspose.Slides.Charts.IMarker marker1 = point1.Marker;
                marker1.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle;
                marker1.Size = 10;

                // Modify marker style for the second point
                Aspose.Slides.Charts.IMarker marker2 = point2.Marker;
                marker2.Symbol = Aspose.Slides.Charts.MarkerStyleType.Square;
                marker2.Size = 12;

                // Remove the third data point (and its marker)
                point3.Remove();

                // Save the presentation
                presentation.Save("ChartMarkers_out.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}