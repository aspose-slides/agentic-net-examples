using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a bubble chart with error bars
        Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f, true);
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        Aspose.Slides.Charts.IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
        errorBarsX.IsVisible = true;
        errorBarsX.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Fixed;
        errorBarsX.Value = 0.5f;
        errorBarsX.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
        errorBarsX.HasEndCap = true;

        Aspose.Slides.Charts.IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
        errorBarsY.IsVisible = true;
        errorBarsY.ValueType = Aspose.Slides.Charts.ErrorBarValueType.Percentage;
        errorBarsY.Value = 10f;
        errorBarsY.Format.Line.Width = 2;

        // Save the presentation as PPTX
        pres.Save("ErrorBarsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Export to HTML and verify markup
        try
        {
            Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();
            pres.Save("ErrorBarsPresentation.html", Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}