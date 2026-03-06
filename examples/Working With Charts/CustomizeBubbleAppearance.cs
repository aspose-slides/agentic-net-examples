using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

public class Program
{
    public static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);

        // Set bubble size representation to Width (bubble radius proportional to size value)
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Optionally adjust the bubble size scale (e.g., 150% of default size)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Save the presentation before exiting
        presentation.Save("CustomizedBubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}