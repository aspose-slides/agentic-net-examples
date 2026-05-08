using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TrendLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a clustered column chart on the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    0f, 0f, 500f, 400f);

                // Add a moving average trend line to the first series
                Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(
                    Aspose.Slides.Charts.TrendlineType.MovingAverage);

                // Configure the trend line
                trendline.DisplayEquation = false;
                trendline.DisplayRSquaredValue = false;
                trendline.Period = 3; // Example period

                // Save the presentation
                presentation.Save("TrendLineChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}