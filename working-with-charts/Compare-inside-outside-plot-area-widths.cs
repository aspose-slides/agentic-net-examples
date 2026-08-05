// -----------------------------------------------------------------------------
// Example: Compare inside and outside plot area widths using C#
//
// Description:
// Demonstrates how to compare the inner and outer plot area widths of a chart 
// using Aspose.Slides for .NET. The example creates a presentation, adds a 
// clustered column chart, sets a manual layout for the plot area, measures the 
// width when the layout target is set to Inner and Outer, and outputs the 
// results. This pattern helps developers understand layout behavior and 
// automate chart sizing validation.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, PlotArea, LayoutTargetType, 
// Inner, Outer, Presentation Automation, Office Automation
//
// Use Cases:
// - Determine differences between inner and outer plot area dimensions.
// - Validate chart layout settings in automated PPTX generation.
// - Build tools that adjust chart layouts based on size constraints.
// - Ensure consistent visual appearance across generated presentations.
// -----------------------------------------------------------------------------

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
