// -----------------------------------------------------------------------------
// Example: Add standard deviation error bars to a scatter chart series using C#
//
// Description:
// Demonstrates how to add standard deviation error bars to a series in a
// scatter chart with smooth lines using C# and Aspose.Slides for .NET.
// The example creates a new presentation, inserts a scatter chart, configures
// both X and Y error bars with a standard deviation multiplier, and saves the
// result as a PPTX file. This pattern can be used to automate chart
// enhancements in PowerPoint presentations.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Scatter Chart, Error Bars,
// Standard Deviation, Chart Automation, Presentation Processing
//
// Use Cases:
// - Add standard deviation error bars to chart series programmatically.
// - Generate PowerPoint presentations with enhanced data visualizations.
// - Integrate chart error bar configuration into .NET reporting tools.
// - Automate preparation of presentation assets for data analysis.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesErrorBarsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a scatter chart with smooth lines
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 50f, 50f, 500f, 400f);

            // Get the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars
            IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
            errorBarsX.IsVisible = true;
            errorBarsX.ValueType = ErrorBarValueType.StandardDeviation;
            errorBarsX.Type = ErrorBarType.Both;
            errorBarsX.Value = 1f; // Standard deviation multiplier

            // Configure Y error bars
            IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
            errorBarsY.IsVisible = true;
            errorBarsY.ValueType = ErrorBarValueType.StandardDeviation;
            errorBarsY.Type = ErrorBarType.Both;
            errorBarsY.Value = 1f; // Standard deviation multiplier

            // Save the presentation
            presentation.Save("ChartWithErrorBars.pptx", SaveFormat.Pptx);
        }
    }
}
