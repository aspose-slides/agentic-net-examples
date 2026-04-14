using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace SetChartLegend
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

                // Ensure the legend is visible
                chart.HasLegend = true;

                // Optionally set legend position (right side)
                chart.Legend.Position = LegendPositionType.Right;

                // Save the presentation
                pres.Save("ChartLegendSeriesNames.pptx", SaveFormat.Pptx);
            }
        }
    }
}