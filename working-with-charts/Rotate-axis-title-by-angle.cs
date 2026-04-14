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
            Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 450, 300);

        // Enable the vertical axis title
        chart.Axes.VerticalAxis.HasTitle = true;

        // Rotate the vertical axis title by 90 degrees
        chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

        // Save the presentation
        presentation.Save("RotatedAxisTitle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}