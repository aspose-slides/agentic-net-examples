using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 500f, 400f);

        // Set bubble size representation to Area for accurate area proportionality
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Area;

        // Save the presentation
        presentation.Save("BubbleChartAreaRepresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}