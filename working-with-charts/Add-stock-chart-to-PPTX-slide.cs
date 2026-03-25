using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a High-Low-Close stock chart to the slide
            IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.HighLowClose, 50, 50, 500, 400);

            // Enable and set the chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("High-Low-Close Stock Chart");

            // Access the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add categories (e.g., months)
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Jan"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Feb"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Mar"));

            // Add a series for the stock data
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.HighLowClose);

            // Populate the series with stock data points (high, low, close)
            series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 120.0));
            series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 115.0));
            series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 118.0));

            // Save the presentation to disk
            pres.Save("StockChartPresentation.pptx", SaveFormat.Pptx);
        }
    }
}