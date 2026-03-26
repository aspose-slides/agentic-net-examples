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
            // Define output file path
            string outputPath = "ClusteredColumnChart.pptx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.ClusteredColumn,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Switch rows and columns in the chart data (demonstrates data manipulation)
            chart.ChartData.SwitchRowColumn();

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}