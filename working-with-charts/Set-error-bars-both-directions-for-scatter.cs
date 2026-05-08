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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a scatter chart with smooth lines
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ScatterWithSmoothLines,
                50, 50, 400, 300);

            // Get the first series of the chart
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Set error bar direction to both positive and negative for X and Y axes
            series.ErrorBarsXFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;
            series.ErrorBarsYFormat.Type = Aspose.Slides.Charts.ErrorBarType.Both;

            // Save the presentation
            presentation.Save("ScatterErrorBars.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., file I/O, unsupported format, web service errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}