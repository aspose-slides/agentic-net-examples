// -----------------------------------------------------------------------------
// Example: Add custom error bars to a line chart using C#
//
// Description:
// Demonstrates how to create a line chart in a new presentation and add
// custom X and Y error bars with individual positive and negative values for
// each data point using Aspose.Slides for .NET. The example shows the required
// steps to configure error bar visibility, set custom value types, assign
// literal double values, and save the resulting PPTX file.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Line Chart, Error Bars, Custom Values,
// ChartDataPoint, Presentation Automation, Office Automation
//
// Use Cases:
// - Generate line charts with precise error bar specifications.
// - Automate addition of custom X/Y error bars in PowerPoint presentations.
// - Build .NET utilities for scientific or financial chart reporting.
// - Validate chart data visualizations before distribution.
// -----------------------------------------------------------------------------
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
