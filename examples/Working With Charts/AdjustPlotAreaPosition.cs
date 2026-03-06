using System;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50,   // X position
            100,  // Y position
            600,  // Width
            400   // Height
        );

        // Adjust the plot area position and size (fractions of the chart dimensions)
        chart.PlotArea.X = 0.2f;          // 20% from the left edge
        chart.PlotArea.Y = 0.2f;          // 20% from the top edge
        chart.PlotArea.Width = 0.7f;      // 70% of the chart width
        chart.PlotArea.Height = 0.7f;     // 70% of the chart height

        // Set layout target type to layout inside the plot area
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

        // Save the presentation
        presentation.Save("AdjustedPlotArea.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}