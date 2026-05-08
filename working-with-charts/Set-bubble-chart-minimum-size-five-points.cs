using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble,
            50,   // X position
            50,   // Y position
            500,  // Width
            400   // Height
        );

        // Set the bubble size scale to ensure a minimum bubble size of five points
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 5;

        // Save the presentation
        presentation.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}