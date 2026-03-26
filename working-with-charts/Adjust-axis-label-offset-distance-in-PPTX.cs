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

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Adjust the category axis label offset (value between 0 and 1000)
        chart.Axes.HorizontalAxis.LabelOffset = (ushort)150;

        // Save the presentation
        presentation.Save("AxisLabelOffset.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}