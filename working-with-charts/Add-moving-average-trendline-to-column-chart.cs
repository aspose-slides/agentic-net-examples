using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Add a moving average trend line to the first series
        ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.MovingAverage);
        trendline.Period = 3; // Set the period for the moving average
        trendline.DisplayEquation = false;
        trendline.DisplayRSquaredValue = false;
        trendline.TrendlineName = "Moving Average";

        // Save the presentation
        presentation.Save("TrendlinePresentation.pptx", SaveFormat.Pptx);
    }
}