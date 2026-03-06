using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);

        // Set bubble size representation to Width
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Set bubble size scale (e.g., 150%)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Save the presentation
        presentation.Save("BubbleChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}