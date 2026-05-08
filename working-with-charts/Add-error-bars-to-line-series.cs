using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ErrorBarsLineChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a line chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 500, 400);

                // Get the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];

                // Enable custom error bars for X and Y directions
                IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
                IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
                errorBarsX.IsVisible = true;
                errorBarsY.IsVisible = true;
                errorBarsX.ValueType = ErrorBarValueType.Custom;
                errorBarsY.ValueType = ErrorBarValueType.Custom;

                // Set the data source type for custom error values to literals
                IChartDataPointCollection points = series.DataPoints;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

                // Assign custom positive and negative error values for each data point
                for (int i = 0; i < points.Count; i++)
                {
                    points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 0.5; // Negative X error
                    points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1.0;  // Positive X error
                    points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 0.2; // Negative Y error
                    points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 0.8;  // Positive Y error
                }

                // Save the presentation
                presentation.Save("ErrorBarsLineChart.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}