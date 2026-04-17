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

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50, 50, 500, 400);

        // Access the first series of the chart
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Configure error bars to use standard deviation for Y values
        series.ErrorBarsYFormat.IsVisible = true;
        series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
        series.ErrorBarsYFormat.ValueType = Aspose.Slides.Charts.ErrorBarValueType.StandardDeviation;
        series.ErrorBarsYFormat.Value = 1; // 1 standard deviation

        // Save the presentation
        try
        {
            presentation.Save("ErrorBarsStandardDeviation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            presentation.Dispose();
        }
    }
}