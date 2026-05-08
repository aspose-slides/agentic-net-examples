using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var outputPath = "Rotated3DChart.pptx";
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Add a 3‑D clustered column chart
            var chart = presentation.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn3D, 50, 50, 500, 400) as Aspose.Slides.Charts.IChart;

            if (chart != null)
            {
                // Set elevation (X rotation) and rotation (Y rotation)
                chart.Rotation3D.RotationX = 30; // Elevation angle
                chart.Rotation3D.RotationY = 45; // Rotation angle
                chart.Rotation3D.RightAngleAxes = false; // Use perspective
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
        }
    }
}