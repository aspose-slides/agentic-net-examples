using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "ChartPlotAreaExample.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

                // Use IChartPlotArea to set plot area layout
                chart.PlotArea.AsILayoutable.X = 0.2f;
                chart.PlotArea.AsILayoutable.Y = 0.2f;
                chart.PlotArea.AsILayoutable.Width = 0.7f;
                chart.PlotArea.AsILayoutable.Height = 0.7f;
                chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, external resources)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}