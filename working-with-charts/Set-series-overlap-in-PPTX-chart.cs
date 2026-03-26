using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartSeriesOverlapDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 10f, 10f, 600f, 300f);

            // Get the series collection
            IChartSeriesCollection series = chart.ChartData.Series;

            // If the first series overlap is zero, set it to 55%
            if (series[0].Overlap == 0)
            {
                series[0].ParentSeriesGroup.Overlap = (sbyte)55;
            }

            // Save the presentation
            presentation.Save("SeriesOverlap.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}