using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Add a 3D clustered column chart
        var chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn3D,
            50f, 50f, 500f, 400f);

        // Configure 3D rotation and perspective
        chart.Rotation3D.RightAngleAxes = false;
        chart.Rotation3D.RotationX = (sbyte)20;          // X-axis rotation
        chart.Rotation3D.RotationY = (ushort)30;         // Y-axis rotation
        chart.Rotation3D.DepthPercents = (ushort)150;    // Depth as % of width
        chart.Rotation3D.HeightPercents = (ushort)100;   // Height as % of width
        chart.Rotation3D.Perspective = (byte)30;         // Perspective angle

        // Add a PieOfPie chart to demonstrate second plot options
        var pieChart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.PieOfPie,
            600f, 50f, 300f, 300f);

        // Show data values on the first series
        pieChart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Configure second pie size and split options
        pieChart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = (ushort)30;
        pieChart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
        pieChart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 10.0;

        // Save the presentation
        presentation.Save("Custom3DChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}