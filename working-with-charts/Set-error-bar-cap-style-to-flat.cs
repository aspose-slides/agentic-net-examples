using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a scatter chart with smooth lines
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                50, 50, 400, 300);

            // Access the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Configure X error bars
            series.ErrorBarsXFormat.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
            series.ErrorBarsXFormat.Value = 0.5f;
            series.ErrorBarsXFormat.HasEndCap = true; // flat cap style

            // Configure Y error bars
            series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Plus;
            series.ErrorBarsYFormat.Value = 0.5f;
            series.ErrorBarsYFormat.HasEndCap = true; // flat cap style

            // Save the presentation
            pres.Save("ErrorBarsFlatCap.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}