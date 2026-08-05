// -----------------------------------------------------------------------------
// Example: Add error bars to line series using C#
//
// Description:
// Demonstrates how to add custom error bars in both X and Y directions to a
// line chart series using C# and Aspose.Slides for .NET. The example creates a
// new presentation, inserts a line chart, configures custom error bar values
// for each data point, and saves the result as a PPTX file. This pattern can be
// used to automate chart enhancements in PowerPoint files.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Line Chart, Error Bars, Custom Error
// Values, Chart Automation, Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically add custom X/Y error bars to line charts.
// - Generate PowerPoint reports with detailed chart error visualizations.
// - Integrate chart error bar configuration into .NET applications.
// - Automate presentation creation and modification workflows.
// -----------------------------------------------------------------------------
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
