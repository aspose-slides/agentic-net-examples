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

        // Set bubble size representation to Width
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Optionally set bubble size scale (e.g., 150%)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Save the presentation
        presentation.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}