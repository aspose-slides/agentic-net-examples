using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ErrorBarsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a line chart to the first slide
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 500, 400);

                // Get the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];

                // Enable custom error bars for X and Y
                IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
                errorBarsX.IsVisible = true;
                errorBarsX.ValueType = ErrorBarValueType.Custom;
                errorBarsX.Type = ErrorBarType.Both;

                IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
                errorBarsY.IsVisible = true;
                errorBarsY.ValueType = ErrorBarValueType.Custom;
                errorBarsY.Type = ErrorBarType.Both;

                // Set data source types for custom error values
                IChartDataPointCollection points = series.DataPoints;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;

                // Assign custom positive and negative error values for each data point
                for (int i = 0; i < points.Count; i++)
                {
                    points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 0.2;
                    points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 0.3;
                    points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 0.4;
                    points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 0.5;
                }

                // Save the presentation
                string outputPath = "ErrorBarsLineChart.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}