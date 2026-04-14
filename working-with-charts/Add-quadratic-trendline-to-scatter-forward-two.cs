using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a scatter chart with smooth lines
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

            // Get the chart data workbook
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Clear any default series and categories
            chart.ChartData.Series.Clear();
            chart.ChartData.Categories.Clear();

            // Add a series to the chart
            chart.ChartData.Series.Add(workbook.GetCell(0, 1, 1, "Series 1"), chart.Type);
            IChartSeries series = chart.ChartData.Series[0];

            // Add data points to the series
            series.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(0, 2, 1, 1),
                workbook.GetCell(0, 2, 2, 3));
            series.DataPoints.AddDataPointForScatterSeries(
                workbook.GetCell(0, 3, 1, 2),
                workbook.GetCell(0, 3, 2, 10));

            // Add a quadratic (polynomial order 2) trend line to the series
            ITrendline trendline = series.TrendLines.Add(TrendlineType.Polynomial);
            trendline.Order = 2;      // Quadratic
            trendline.Forward = 2;    // Extend forward by two category units

            // Save the presentation
            presentation.Save("ScatterChartWithQuadraticTrendline.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}