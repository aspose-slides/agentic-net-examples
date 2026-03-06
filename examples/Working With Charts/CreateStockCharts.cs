class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a High-Low-Close stock chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.HighLowClose, 50f, 50f, 600f, 400f);

        // Access the chart's data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Add a series name
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

        // Add categories (e.g., months)
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Jan"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Feb"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Mar"));

        // Add data points: High, Low, Close for each category
        // Jan
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 120.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 80.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 100.0));
        // Feb
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 130.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 85.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 115.0));
        // Mar
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 125.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 90.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 110.0));

        // Save the presentation
        presentation.Save("StockChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}