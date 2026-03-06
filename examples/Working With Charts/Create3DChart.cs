using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a 3D clustered column chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn3D, 50f, 50f, 600f, 400f);

            // Configure 3D rotation properties
            chart.Rotation3D.DepthPercents = 200;      // Depth as a percentage of chart width
            chart.Rotation3D.HeightPercents = 150;     // Height as a percentage of chart width
            chart.Rotation3D.RotationX = 20;           // Rotation around X axis
            chart.Rotation3D.RotationY = 30;           // Rotation around Y axis

            // Save the presentation to a PPTX file
            presentation.Save("3DChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}