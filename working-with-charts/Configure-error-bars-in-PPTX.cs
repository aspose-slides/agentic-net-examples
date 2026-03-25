using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ErrorBarsOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a Bubble chart with sample data
                IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 0f, 0f, 500f, 400f, true);

                // Get the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];

                // Configure X error bars (fixed value, visible, plus type, with end cap)
                IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
                errorBarsX.IsVisible = true;
                errorBarsX.ValueType = ErrorBarValueType.Fixed;
                errorBarsX.Value = 5f; // Fixed length of 5 points
                errorBarsX.Type = ErrorBarType.Plus;
                errorBarsX.HasEndCap = true;

                // Configure Y error bars (percentage value, visible, line width set)
                IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
                errorBarsY.IsVisible = true;
                errorBarsY.ValueType = ErrorBarValueType.Percentage;
                errorBarsY.Value = 10f; // 10 percent of the data value
                errorBarsY.Format.Line.Width = 2;

                // Switch to custom error bars for both X and Y
                errorBarsX.ValueType = ErrorBarValueType.Custom;
                errorBarsY.ValueType = ErrorBarValueType.Custom;

                // Set data source type for custom error values (using literal doubles)
                IChartDataPointCollection points = series.DataPoints;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
                points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

                // Assign custom error values for each data point
                for (int i = 0; i < points.Count; i++)
                {
                    points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 0.5;
                    points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1.0;
                    points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 0.3;
                    points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 0.8;
                }

                // Save the presentation
                presentation.Save("ErrorBarsOverview.pptx", SaveFormat.Pptx);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("Required file not found: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}