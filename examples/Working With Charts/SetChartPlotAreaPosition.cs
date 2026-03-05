using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a chart to the slide
        Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 20, 100, 600, 400);

        // Adjust plot area position and size (as fractions of chart size)
        chart.PlotArea.X = 0.1f; // 10% from left
        chart.PlotArea.Y = 0.1f; // 10% from top
        chart.PlotArea.Width = 0.8f; // 80% width
        chart.PlotArea.Height = 0.8f; // 80% height

        // Set layout target type (optional)
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

        // Save the presentation
        presentation.Save("AdjustedPlotArea.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}