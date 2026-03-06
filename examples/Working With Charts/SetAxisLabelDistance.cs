using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Set the distance of the category axis labels from the axis (value in percent, 0-1000)
        chart.Axes.HorizontalAxis.LabelOffset = (ushort)100;

        // Save the presentation
        presentation.Save("SetAxisLabelDistance_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}