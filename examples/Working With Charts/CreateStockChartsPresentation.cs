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

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a High-Low-Close stock chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.HighLowClose,
            50f, 50f, 600f, 400f);

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear any default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Index of the default worksheet
        int defaultWorksheetIndex = 0;

        // Add categories (e.g., dates)
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 1, 0, "Day 1"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 2, 0, "Day 2"));
        chart.ChartData.Categories.Add(workbook.GetCell(defaultWorksheetIndex, 3, 0, "Day 3"));

        // Add a series name
        chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Stock Series"),
            chart.Type);

        // Retrieve the created series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Add data points for each category (high, low, close values)
        series.DataPoints.AddDataPointForStockSeries(120.0); // Day 1
        series.DataPoints.AddDataPointForStockSeries(115.0);
        series.DataPoints.AddDataPointForStockSeries(118.0);

        series.DataPoints.AddDataPointForStockSeries(122.0); // Day 2
        series.DataPoints.AddDataPointForStockSeries(119.0);
        series.DataPoints.AddDataPointForStockSeries(121.0);

        series.DataPoints.AddDataPointForStockSeries(125.0); // Day 3
        series.DataPoints.AddDataPointForStockSeries(123.0);
        series.DataPoints.AddDataPointForStockSeries(124.0);

        // Save the presentation
        presentation.Save("StockChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}