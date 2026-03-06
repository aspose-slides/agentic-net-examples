using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);

        // Set the bubble size scaling factor (e.g., 150% of the default size)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Save the presentation
        presentation.Save("BubbleChartScaling.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}