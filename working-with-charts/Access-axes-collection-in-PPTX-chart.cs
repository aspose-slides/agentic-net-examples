using System;
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

        // Position the horizontal axis between categories
        chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

        // Set the distance of category axis labels
        chart.Axes.HorizontalAxis.LabelOffset = (ushort)20;

        // Save the presentation
        presentation.Save("ManipulateAxes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}