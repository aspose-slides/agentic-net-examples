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
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);

        // Access the horizontal (category) axis of the chart
        Aspose.Slides.Charts.IAxis categoryAxis = chart.Axes.HorizontalAxis;

        // Set the distance of labels from the axis (e.g., 200 = 20%)
        categoryAxis.LabelOffset = (ushort)200;

        // Save the presentation to a file
        presentation.Save("SetLabelOffset_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}