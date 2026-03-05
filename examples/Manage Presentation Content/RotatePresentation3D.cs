using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 450f, 300f);

        // Configure 3D rotation for the chart
        chart.Rotation3D.RightAngleAxes = false;                     // Use perspective view
        chart.Rotation3D.RotationX = (sbyte)30;                      // Rotate around X-axis
        chart.Rotation3D.RotationY = (ushort)45;                     // Rotate around Y-axis
        chart.Rotation3D.DepthPercents = (ushort)200;                // Set depth percentage

        // Save the presentation in PPTX format
        presentation.Save("3DChartRotation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}