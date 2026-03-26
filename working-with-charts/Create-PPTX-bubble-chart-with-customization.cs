using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);

        // Set bubble size scaling (e.g., 150% of default size)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Represent bubble size by width (radius)
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Show bubble size values in data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

        // Save the presentation
        presentation.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}