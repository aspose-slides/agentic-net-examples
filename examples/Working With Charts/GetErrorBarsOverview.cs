using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];
            // Add a scatter chart with smooth lines
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines, 50f, 50f, 500f, 400f);
            // Get the first series
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];
            // Configure X error bars
            series.ErrorBarsXFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
            series.ErrorBarsXFormat.Value = 0.5f;
            // Configure Y error bars
            series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
            series.ErrorBarsYFormat.Value = 0.5f;
            // Save the presentation
            pres.Save("ErrorBarsOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}