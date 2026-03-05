using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);

        // Get the axes manager (collection of axes) from the chart
        Aspose.Slides.Charts.IAxesManager axes = chart.Axes;

        // Example: set the horizontal axis to be positioned between categories
        axes.HorizontalAxis.AxisBetweenCategories = true;

        // Example: set the label offset for the horizontal axis (value must be UInt16)
        axes.HorizontalAxis.LabelOffset = (ushort)100;

        // Save the presentation
        presentation.Save("AxesCollection_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}