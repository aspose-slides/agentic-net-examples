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

        // Add a 3‑D chart (ClusteredColumn supports 3‑D view)
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);

        // Configure 3‑D rotation
        chart.Rotation3D.RightAngleAxes = false; // enable perspective
        chart.Rotation3D.RotationX = 30; // elevation angle (Y‑axis rotation)
        chart.Rotation3D.RotationY = 45; // rotation angle (X‑axis rotation)

        // Save the presentation
        try
        {
            presentation.Save("3DChartRotation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Clean up
        presentation.Dispose();
    }
}