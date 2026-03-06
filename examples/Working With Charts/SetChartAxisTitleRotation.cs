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
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

        // Ensure the vertical axis has a title and set its text
        chart.Axes.VerticalAxis.HasTitle = true;
        chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Y Axis");

        // Set the rotation angle for the vertical axis title
        chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90f;

        // Save the presentation
        presentation.Save("SetChartAxisTitleRotation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}