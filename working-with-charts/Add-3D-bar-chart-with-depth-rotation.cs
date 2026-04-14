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

        // Add a new slide based on the layout of the first slide
        Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

        // Add a 3D stacked column chart (used as a 3D bar chart)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.StackedColumn3D, 50f, 50f, 500f, 400f);

        // Set 3D rotation properties
        chart.Rotation3D.RightAngleAxes = false;
        chart.Rotation3D.RotationX = (sbyte)20;          // Rotation around X-axis
        chart.Rotation3D.RotationY = (ushort)30;        // Rotation around Y-axis
        chart.Rotation3D.DepthPercents = (ushort)200;   // Depth as percentage of chart width
        chart.Rotation3D.HeightPercents = (ushort)150;  // Height as percentage of chart width

        // Add a title to the chart
        chart.HasTitle = true;
        chart.ChartTitle.AddTextFrameForOverriding("3D Bar Chart");

        // Save the presentation
        presentation.Save("3DBarChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}