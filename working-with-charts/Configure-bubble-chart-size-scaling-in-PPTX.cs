using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a bubble chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 500, 400);

        // Configure bubble size scaling (e.g., 150% of default size)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Save the presentation
        presentation.Save("BubbleChartScaling.pptx", SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}