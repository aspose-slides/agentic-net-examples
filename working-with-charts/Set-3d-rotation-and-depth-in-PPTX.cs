using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace Chart3DRotationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "3DChartRotation.pptx";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.ClusteredColumn,
                50,   // X position
                50,   // Y position
                450,  // Width
                300   // Height
            );

            // Configure 3D rotation properties
            chart.Rotation3D.RotationX = 30;      // Rotate around X-axis (degrees, -90 to 90)
            chart.Rotation3D.RotationY = 45;      // Rotate around Y-axis (degrees, 0 to 360)
            chart.Rotation3D.DepthPercents = 200; // Depth as percent of chart width (20 to 2000)

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}