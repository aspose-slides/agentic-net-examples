using System;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a High-Low-Close stock chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.HighLowClose,
            50f, 50f, 500f, 400f);

        // Set chart title
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("High-Low-Close Stock Chart");

        // Access the chart data workbook
        Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

        // Clear default series and categories
        chart.ChartData.Series.Clear();
        chart.ChartData.Categories.Clear();

        // Add categories (e.g., months)
        chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Jan"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Feb"));
        chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Mar"));

        // Add a series
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
            workbook.GetCell(0, 0, 1, "Series 1"),
            Aspose.Slides.Charts.ChartType.HighLowClose);

        // First category data points (High, Low, Close)
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 120.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 80.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 100.0));

        // Second category data points
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 130.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 85.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 110.0));

        // Third category data points
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 125.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 90.0));
        series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 115.0));

        // Save the presentation
        pres.Save("StockChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}