using System;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "3DChartPresentation.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a 3D clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn3D,
            50f, 50f, 600f, 400f);

        // Configure 3D rotation properties
        chart.Rotation3D.DepthPercents = 200;      // Depth as a percentage of chart width
        chart.Rotation3D.HeightPercents = 150;     // Height as a percentage of chart width
        chart.Rotation3D.RotationX = -30;          // X-axis rotation (sbyte)
        chart.Rotation3D.RotationY = 30;           // Y-axis rotation (ushort)

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}