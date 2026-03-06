using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a High‑Low‑Close stock chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.HighLowClose, 50f, 50f, 600f, 400f);

        // Get the workbook that holds chart data
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Remove the default sample series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories (e.g., months)
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Jan"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Feb"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Mar"));

        // Add a series for the stock data
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add data points (high, low, close) for each category
        // First month
        Aspose.Slides.Charts.IChartDataCell cell1 = workbook.GetCell(0, 1, 1, 30.0);
        series.DataPoints.AddDataPointForStockSeries(cell1);
        // Second month
        Aspose.Slides.Charts.IChartDataCell cell2 = workbook.GetCell(0, 2, 1, 40.0);
        series.DataPoints.AddDataPointForStockSeries(cell2);
        // Third month
        Aspose.Slides.Charts.IChartDataCell cell3 = workbook.GetCell(0, 3, 1, 35.0);
        series.DataPoints.AddDataPointForStockSeries(cell3);

        // Save the presentation to a PPTX file
        presentation.Save("StockChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}