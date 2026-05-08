using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a clustered column chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);

        // Set the position of the horizontal axis to the bottom of the plot area
        chart.Axes.HorizontalAxis.Position = Aspose.Slides.Charts.AxisPositionType.Bottom;

        // Set the position of the vertical axis to the left of the plot area
        chart.Axes.VerticalAxis.Position = Aspose.Slides.Charts.AxisPositionType.Left;

        // Save the presentation
        presentation.Save("ChartAxisPosition.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}