using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var pres = new Aspose.Slides.Presentation();
        // Access the first slide
        var slide = pres.Slides[0];
        // Add an Area chart
        var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Area, 50, 50, 500, 400);
        // Validate layout to ensure actual values are calculated
        chart.ValidateChartLayout();

        // Configure vertical axis scaling
        var verticalAxis = chart.Axes.VerticalAxis;
        verticalAxis.IsAutomaticMinValue = false;
        verticalAxis.IsAutomaticMaxValue = false;
        verticalAxis.IsAutomaticMajorUnit = false;
        verticalAxis.IsAutomaticMinorUnit = false;
        verticalAxis.MinValue = 0;
        verticalAxis.MaxValue = 100;
        verticalAxis.MajorUnit = 20;
        verticalAxis.MinorUnit = 5;

        // Configure horizontal axis scaling (optional)
        var horizontalAxis = chart.Axes.HorizontalAxis;
        horizontalAxis.IsAutomaticMajorUnit = false;
        horizontalAxis.IsAutomaticMinorUnit = false;
        horizontalAxis.MajorUnit = 10;
        horizontalAxis.MinorUnit = 2;

        // Save the presentation
        var outPath = "AxisScaling_out.pptx";
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        // Dispose the presentation
        pres.Dispose();
    }
}