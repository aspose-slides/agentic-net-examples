using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartSeriesOverlapExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn,
                    10f,   // X position
                    10f,   // Y position
                    600f,  // Width
                    300f   // Height
                );

                // Access the series collection
                IChartSeriesCollection series = chart.ChartData.Series;

                // Set overlap to 55% if the current value is zero
                if (series[0].Overlap == 0)
                {
                    series[0].ParentSeriesGroup.Overlap = (sbyte)55;
                }

                // Save the presentation
                string outputPath = "ChartSeriesOverlap.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}