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