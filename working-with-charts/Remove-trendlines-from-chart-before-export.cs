using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Remove all trend lines from each series
        for (int i = 0; i < chart.ChartData.Series.Count; i++)
        {
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[i];
            var trendlines = new System.Collections.Generic.List<Aspose.Slides.Charts.ITrendline>();
            foreach (Aspose.Slides.Charts.ITrendline tl in series.TrendLines)
            {
                trendlines.Add(tl);
            }
            foreach (Aspose.Slides.Charts.ITrendline tl in trendlines)
            {
                series.TrendLines.Remove(tl);
            }
        }

        // Get chart image
        Aspose.Slides.IImage image = chart.GetImage();

        // Save chart image as PNG
        try
        {
            image.Save("ChartImage.png", Aspose.Slides.ImageFormat.Png);
        }
        catch (System.Exception)
        {
            // Format not supported or other error handling
        }

        // Save the presentation
        presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}