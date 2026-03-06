using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart with sample data
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble,
            0f, 0f, 500f, 500f, true);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Configure X error bars
        Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
        errorBarsX.IsVisible = true;
        errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
        errorBarsX.Value = 5f;
        errorBarsX.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
        errorBarsX.HasEndCap = false;

        // Configure Y error bars
        Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
        errorBarsY.IsVisible = true;
        errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage;
        errorBarsY.Value = 10;
        errorBarsY.Format.Line.Width = 2;

        // Save the presentation
        presentation.Save("AddErrorBars_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}