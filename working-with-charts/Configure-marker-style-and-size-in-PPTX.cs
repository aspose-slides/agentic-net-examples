using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a line chart with markers
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.LineWithMarkers, 50f, 50f, 500f, 400f);

            // Clear default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Get the chart data workbook
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Add a series
            chart.ChartData.Series.Add(
                workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Add categories
            chart.ChartData.Categories.Add(
                workbook.GetCell(0, 1, 0, "Category 1"));
            chart.ChartData.Categories.Add(
                workbook.GetCell(0, 2, 0, "Category 2"));

            // Populate series with data points
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            series.DataPoints.AddDataPointForLineSeries(
                workbook.GetCell(0, 1, 1, 20));
            series.DataPoints.AddDataPointForLineSeries(
                workbook.GetCell(0, 2, 1, 30));

            // Configure marker style and size
            series.Marker.Size = 10; // Marker size
            series.Marker.Symbol = Aspose.Slides.Charts.MarkerStyleType.Circle; // Marker shape

            // Save the presentation
            pres.Save("MarkerStyleDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}