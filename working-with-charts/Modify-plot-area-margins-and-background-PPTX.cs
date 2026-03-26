using System;
using Aspose.Slides.Export;

namespace ChartPlotAreaCustomization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);
            // Customize the plot area layout
            chart.PlotArea.AsILayoutable.X = 0.2f;
            chart.PlotArea.AsILayoutable.Y = 0.2f;
            chart.PlotArea.AsILayoutable.Width = 0.7f;
            chart.PlotArea.AsILayoutable.Height = 0.7f;
            chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;
            // Save the presentation
            presentation.Save("CustomizedPlotArea.pptx", SaveFormat.Pptx);
        }
    }
}