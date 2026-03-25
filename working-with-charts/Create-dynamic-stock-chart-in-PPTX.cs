using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // No external input files are required for this example.
        // Create a new presentation.
        using (Presentation pres = new Presentation())
        {
            // Get the first slide.
            ISlide slide = pres.Slides[0];

            // Add a High-Low-Close stock chart.
            IChart chart = slide.Shapes.AddChart(ChartType.HighLowClose, 0f, 0f, 500f, 400f);

            // Access the chart's workbook.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Remove the default sample series and categories.
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a new series.
            IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

            // Set the data source type to accept literal double values.
            series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;

            // Add categories (e.g., months).
            chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Jan"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Feb"));
            chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Mar"));

            // Populate the series with stock data points (high, low, close values).
            series.DataPoints.AddDataPointForStockSeries(120.0); // High for Jan
            series.DataPoints.AddDataPointForStockSeries(115.0); // Low for Jan
            series.DataPoints.AddDataPointForStockSeries(118.0); // Close for Jan

            series.DataPoints.AddDataPointForStockSeries(125.0); // High for Feb
            series.DataPoints.AddDataPointForStockSeries(110.0); // Low for Feb
            series.DataPoints.AddDataPointForStockSeries(122.0); // Close for Feb

            series.DataPoints.AddDataPointForStockSeries(130.0); // High for Mar
            series.DataPoints.AddDataPointForStockSeries(120.0); // Low for Mar
            series.DataPoints.AddDataPointForStockSeries(128.0); // Close for Mar

            // Save the presentation.
            try
            {
                pres.Save("DynamicStockChart.pptx", SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}