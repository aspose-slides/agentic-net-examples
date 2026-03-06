using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (a default blank slide is created)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a bubble chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Bubble, 50, 50, 500, 400);

        // Access the series group of the first series (all series share the same group)
        Aspose.Slides.Charts.IChartSeriesGroup seriesGroup = chart.ChartData.Series[0].ParentSeriesGroup;

        // Set the bubble size scaling factor (e.g., 150% of the default size)
        seriesGroup.BubbleSizeScale = 150;

        // Optionally, set how bubble sizes are represented (Area or Width)
        seriesGroup.BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Area;

        // Save the presentation to a file
        presentation.Save("BubbleChartSizeScaling.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}