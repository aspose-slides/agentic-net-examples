using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart (3D enabled by default)
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);

        // Configure 3D rotation properties
        chart.Rotation3D.RotationX = 30; // Rotation around X-axis
        chart.Rotation3D.RotationY = 40; // Rotation around Y-axis
        chart.Rotation3D.DepthPercents = 150; // Depth as a percentage of chart width

        // Save the presentation
        string outputPath = "3DChartRotation.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}