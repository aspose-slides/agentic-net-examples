using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "AxisPositionDemo.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Set the category (horizontal) axis position to Bottom
        chart.Axes.HorizontalAxis.Position = Aspose.Slides.Charts.AxisPositionType.Bottom;

        // Set the value (vertical) axis position to Left
        chart.Axes.VerticalAxis.Position = Aspose.Slides.Charts.AxisPositionType.Left;

        // Save the presentation before exiting
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}