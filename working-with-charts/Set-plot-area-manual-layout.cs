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

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 450f, 300f);

        // Manually set plot area layout (X, Y, Width, Height as fractions of the chart size)
        chart.PlotArea.AsILayoutable.X = 0.1f;
        chart.PlotArea.AsILayoutable.Y = 0.1f;
        chart.PlotArea.AsILayoutable.Width = 0.8f;
        chart.PlotArea.AsILayoutable.Height = 0.8f;

        // Define layout target type (inner excludes axis labels)
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

        // Save the presentation
        presentation.Save("ManualLayoutChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}