using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a line chart with sample data to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50f, 50f, 500f, 400f, true);

            // Ensure the chart type supports trend lines
            if (ChartTypeCharacterizer.HasSeriesTrendLines(chart.Type))
            {
                // Add an exponential trend line to the first series
                ITrendline expTrendline = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
                expTrendline.DisplayEquation = false;
                expTrendline.DisplayRSquaredValue = false;
            }

            // Save the presentation
            try
            {
                pres.Save("LineChartWithExponentialTrendline.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle cases where the format is not supported
                // Format not supported: ex.Message
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}