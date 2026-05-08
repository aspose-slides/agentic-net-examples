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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a scatter chart with smooth lines
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
            50f, 50f, 400f, 300f);

        // Get the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Set error bar direction to both positive and negative for X and Y axes
        series.ErrorBarsXFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
        series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;

        // Save the presentation
        try
        {
            presentation.Save("ScatterErrorBars.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}