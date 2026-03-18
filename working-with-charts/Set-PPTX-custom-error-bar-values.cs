using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetCustomErrorBarValues
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = pres.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                    // Get the chart data workbook
                    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                    // Clear default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add a new series
                    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);
                    // Add categories
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
                    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

                    // Add data points to the series
                    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 20));
                    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 50));
                    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 30));

                    // Configure custom error bars for Y direction
                    IErrorBarsFormat errorBars = series.ErrorBarsYFormat;
                    // Set the error bar type (both positive and negative)
                    errorBars.Type = ErrorBarType.Both;
                    // Specify that custom values will be used
                    errorBars.ValueType = ErrorBarValueType.Custom;

                    // Example: set custom error values for the first data point
                    IChartDataPoint point = series.DataPoints[0];
                    // The YPlus and YMinus properties are read‑only IDoubleChartValue objects.
                    // Their Data property can be set to a literal double value.
                    point.ErrorBarsCustomValues.YPlus.Data = 5.0;   // Positive error
                    point.ErrorBarsCustomValues.YMinus.Data = 3.0; // Negative error

                    // Save the presentation
                    pres.Save("CustomErrorBars.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}