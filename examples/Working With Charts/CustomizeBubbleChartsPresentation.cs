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
            Aspose.Slides.Charts.ChartType.Bubble,
            50f,   // X position
            50f,   // Y position
            600f,  // Width
            400f   // Height
        );

        // Set bubble size representation to Width
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Set bubble size scale (e.g., 150% of default size)
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;

        // Optional: customize data labels to show bubble size values
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowBubbleSize = true;

        // Save the presentation
        presentation.Save("CustomizedBubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}