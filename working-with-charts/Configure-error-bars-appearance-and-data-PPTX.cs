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
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a Bubble chart to the first slide with sample data
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.Bubble,
                50f, 50f, 500f, 400f,
                true);

            // Get the first series of the chart
            IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars
            IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
            errorBarsX.IsVisible = true;
            errorBarsX.ValueType = ErrorBarValueType.Fixed;
            errorBarsX.Value = 0.5f;
            errorBarsX.Type = ErrorBarType.Plus;
            errorBarsX.HasEndCap = true;

            // Configure Y error bars
            IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
            errorBarsY.IsVisible = true;
            errorBarsY.ValueType = ErrorBarValueType.Percentage;
            errorBarsY.Value = 10f;
            errorBarsY.Format.Line.Width = 2;
            errorBarsY.Type = ErrorBarType.Plus;
            errorBarsY.HasEndCap = true;

            // Save the presentation
            presentation.Save("ErrorBarsChart.pptx", SaveFormat.Pptx);
        }
    }
}