using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a bubble chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 500f, 400f);

        // Set bubble size representation to Width for proportional scaling
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

        // Save the presentation
        string outputPath = "BubbleChart.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}