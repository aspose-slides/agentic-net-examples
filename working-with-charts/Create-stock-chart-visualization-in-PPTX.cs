using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a High-Low-Close stock chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.HighLowClose,
            50f, 50f, 500f, 400f);

        // Index of the default worksheet
        int defaultWorksheetIndex = 0;

        // Get the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add a series
        chart.ChartData.Series.Add(
            workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
            chart.Type);

        // Add categories (e.g., months)
        chart.ChartData.Categories.Add(
            workbook.GetCell(defaultWorksheetIndex, 1, 0, "Jan"));
        chart.ChartData.Categories.Add(
            workbook.GetCell(defaultWorksheetIndex, 2, 0, "Feb"));
        chart.ChartData.Categories.Add(
            workbook.GetCell(defaultWorksheetIndex, 3, 0, "Mar"));

        // Populate series with stock values (High, Low, Close)
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
        series.DataPoints.AddDataPointForStockSeries(
            workbook.GetCell(defaultWorksheetIndex, 1, 1, 120.0));
        series.DataPoints.AddDataPointForStockSeries(
            workbook.GetCell(defaultWorksheetIndex, 2, 1, 115.0));
        series.DataPoints.AddDataPointForStockSeries(
            workbook.GetCell(defaultWorksheetIndex, 3, 1, 118.0));

        // Save the presentation
        presentation.Save("StockChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}