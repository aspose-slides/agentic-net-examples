using System;
using Aspose.Slides.Export;

namespace BubbleChartScaling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Output file path
                var outputPath = "BubbleChartScaling.pptx";

                // Create a new presentation
                var presentation = new Aspose.Slides.Presentation();

                // Add a bubble chart to the first slide
                var chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Bubble, 50, 50, 500, 400);

                // Configure bubble size scaling (e.g., 150% of default size)
                chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}