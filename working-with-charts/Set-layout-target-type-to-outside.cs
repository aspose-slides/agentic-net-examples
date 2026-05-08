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

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

        // Define manual layout for the plot area
        chart.PlotArea.AsILayoutable.X = 0.2f;
        chart.PlotArea.AsILayoutable.Y = 0.2f;
        chart.PlotArea.AsILayoutable.Width = 0.7f;
        chart.PlotArea.AsILayoutable.Height = 0.7f;

        // Set layout target type to Outer so axes are included within the plotted region
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Outer;

        // Save the presentation
        presentation.Save("ChartWithOuterLayout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}