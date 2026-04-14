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

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

        // Define manual layout for the plot area (fraction of chart size)
        chart.PlotArea.AsILayoutable.X = 0.2f;
        chart.PlotArea.AsILayoutable.Y = 0.2f;
        chart.PlotArea.AsILayoutable.Width = 0.7f;
        chart.PlotArea.AsILayoutable.Height = 0.7f;

        // Measure plot area width with Inner layout target
        chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
        chart.ValidateChartLayout();
        float innerWidth = chart.PlotArea.ActualWidth;

        // Measure plot area width with Outer layout target
        chart.PlotArea.LayoutTargetType = LayoutTargetType.Outer;
        chart.ValidateChartLayout();
        float outerWidth = chart.PlotArea.ActualWidth;

        // Output the comparison results
        Console.WriteLine("Inner layout plot area width: " + innerWidth);
        Console.WriteLine("Outer layout plot area width: " + outerWidth);

        // Save the presentation
        string outputPath = "ChartLayoutComparison.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}