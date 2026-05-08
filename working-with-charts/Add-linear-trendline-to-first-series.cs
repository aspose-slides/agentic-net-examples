using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesTrendLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 600f, 400f);

            // Add a linear trend line to the first data series
            ITrendline linearTrend = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
            linearTrend.DisplayEquation = false;
            linearTrend.DisplayRSquaredValue = false;

            // Save the presentation
            try
            {
                presentation.Save("TrendLineExample.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during saving
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}