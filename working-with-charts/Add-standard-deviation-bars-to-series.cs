using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a scatter chart (supports error bars on both axes)
        IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 50, 50, 500, 400);

        // Get the first series of the chart
        IChartSeries series = chart.ChartData.Series[0];

        // Configure Y error bars to use standard deviation
        IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
        errorBarsY.IsVisible = true;
        errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.StandardDeviation;
        errorBarsY.Value = 1f; // multiplier for standard deviation

        // Configure X error bars similarly (if supported)
        IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
        if (errorBarsX != null)
        {
            errorBarsX.IsVisible = true;
            errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.StandardDeviation;
            errorBarsX.Value = 1f;
        }

        // Save the presentation
        presentation.Save("ChartWithStdDevErrorBars.pptx", SaveFormat.Pptx);
    }
}