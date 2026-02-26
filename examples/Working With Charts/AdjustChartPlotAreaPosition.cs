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

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);

        // Adjust the plot area position and size (fractions of the chart dimensions)
        chart.PlotArea.AsILayoutable.X = 0.2f;
        chart.PlotArea.AsILayoutable.Y = 0.2f;
        chart.PlotArea.AsILayoutable.Width = 0.7f;
        chart.PlotArea.AsILayoutable.Height = 0.7f;

        // Set the layout target type to inner (inside the axes)
        chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

        // Save the presentation to disk
        presentation.Save("AdjustPlotArea_out.pptx", SaveFormat.Pptx);
    }
}