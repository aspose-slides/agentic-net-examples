using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a 3D clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn3D,
            50f,   // X position
            50f,   // Y position
            500f,  // Width
            400f   // Height
        );

        // Customize 3D rotation and perspective
        chart.Rotation3D.DepthPercents = 200;               // Depth as % of chart width
        chart.Rotation3D.HeightPercents = 150;              // Height as % of chart width
        chart.Rotation3D.RotationX = (sbyte)30;             // Rotation around X‑axis
        chart.Rotation3D.RotationY = 40;                    // Rotation around Y‑axis
        chart.Rotation3D.Perspective = 30;                  // Perspective (field of view)
        chart.Rotation3D.RightAngleAxes = false;            // Use perspective view

        // Save the presentation
        presentation.Save("Customize3DChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}