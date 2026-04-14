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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Set the distance of axis labels from the axis (LabelOffset) – value must be between 0 and 1000
        chart.Axes.HorizontalAxis.LabelOffset = (ushort)150;

        // Save the presentation
        presentation.Save("ChartLabelOffset.pptx", SaveFormat.Pptx);
    }
}