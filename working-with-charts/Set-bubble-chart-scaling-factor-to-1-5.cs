using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a bubble chart to the slide
            IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 500f, 400f);

            // Get the first series (default series is created)
            IChartSeries series = chart.ChartData.Series[0];

            // Set the bubble size scaling factor to 150% (1.5)
            series.ParentSeriesGroup.BubbleSizeScale = 150;

            // Save the presentation
            try
            {
                pres.Save("BubbleChartScaling.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}