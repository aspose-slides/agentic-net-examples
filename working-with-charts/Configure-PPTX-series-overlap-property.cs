using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 10f, 10f, 600f, 300f);

                // Get the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];

                // Set the overlap of the series group to 55%
                series.ParentSeriesGroup.Overlap = 55;

                // Save the presentation to a PPTX file
                pres.Save("ChartOverlap.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}