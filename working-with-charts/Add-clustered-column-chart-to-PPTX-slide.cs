using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "ClusteredColumnChart.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart to the first slide
                // Parameters: chart type, X position, Y position, width, height
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn,
                    50f,   // X
                    50f,   // Y
                    500f,  // Width
                    400f   // Height
                );

                // Switch rows and columns in the chart data (optional demonstration)
                chart.ChartData.SwitchRowColumn();

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}