using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a bubble chart with sample data
                IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 0f, 0f, 500f, 400f);

                // Ensure the chart type is a bubble chart
                if (!ChartTypeCharacterizer.IsChartTypeBubble(chart.Type))
                {
                    // If not a bubble chart, exit
                    return;
                }

                // Get the first series (creates one if none exists)
                IChartSeries series = chart.ChartData.Series[0];

                // Set the minimum bubble size to five points via the series group scale
                // (BubbleSizeScale is an integer representing the scale factor; using 5 as the required minimum)
                series.ParentSeriesGroup.BubbleSizeScale = 5;

                // Save the presentation
                try
                {
                    pres.Save("BubbleChart_MinSize.pptx", SaveFormat.Pptx);
                }
                catch (System.NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}