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

        // Add a clustered column chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

        // Manually set the plot area layout using fractional coordinates
        chart.PlotArea.AsILayoutable.X = 0.1f;      // 10% from the left
        chart.PlotArea.AsILayoutable.Y = 0.1f;      // 10% from the top
        chart.PlotArea.AsILayoutable.Width = 0.8f;  // 80% of the chart width
        chart.PlotArea.AsILayoutable.Height = 0.8f; // 80% of the chart height

        // Define how the layout should be applied (inner area)
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

        // Save the presentation
        presentation.Save("ManualLayoutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}