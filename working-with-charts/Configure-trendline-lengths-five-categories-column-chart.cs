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

        // Add a clustered column chart on the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Add a linear trendline to the first series
        Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(Aspose.Slides.Charts.TrendlineType.Linear);

        // Set forward and backward lengths to five categories
        trendline.Forward = 5;
        trendline.Backward = 5;

        // Save the presentation
        presentation.Save("TrendlineForwardBackward.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}