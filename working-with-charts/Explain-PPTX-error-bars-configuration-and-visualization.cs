using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ErrorBarsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a blank slide
                ISlide slide = presentation.Slides[0];

                // Define chart position and size
                float chartX = 50f;
                float chartY = 50f;
                float chartWidth = 500f;
                float chartHeight = 400f;

                // Add a clustered bar chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredBar, chartX, chartY, chartWidth, chartHeight).Chart;

                // Access chart data workbook
                IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));

                // Add a series
                IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "B1", "Series 1"), chart.Type);

                // Populate series data
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B2", 20));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B3", 50));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B4", 30));

                // Configure Y-direction error bars
                IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
                if (errorBarsY != null)
                {
                    errorBarsY.IsVisible = true;
                    errorBarsY.Type = ErrorBarType.Both;
                    errorBarsY.ValueType = ErrorBarValueType.StandardDeviation;
                    errorBarsY.Value = 1.0f; // Used with StandardDeviation value type
                }

                // Configure X-direction error bars if supported for this chart type
                if (ChartTypeCharacterizer.IsErrorBarsXAllowed(chart.Type))
                {
                    IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
                    if (errorBarsX != null)
                    {
                        errorBarsX.IsVisible = true;
                        errorBarsX.Type = ErrorBarType.Both;
                        errorBarsX.ValueType = ErrorBarValueType.Percentage;
                        errorBarsX.Value = 10.0f; // 10 percent error bars
                    }
                }

                // Save the presentation
                presentation.Save("ErrorBarsDemo.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}