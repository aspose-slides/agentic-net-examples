// -----------------------------------------------------------------------------
// Example: Fallback layout target type to inside using C#
//
// Description:
// Demonstrates how to set a chart's plot area layout target to Outer and
// automatically fallback to Inner when the resulting dimensions are invalid.
// The example creates a clustered column chart, defines a manual layout for
// the plot area, validates the layout, and switches the LayoutTargetType to
// Inner if the calculated width or height becomes negative. The resulting
// presentation is saved as a PPTX file using Aspose.Slides for .NET.
// This pattern helps developers ensure robust chart layout handling in
// PowerPoint automation scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, PlotArea, LayoutTargetType,
// Outer, Inner, Fallback, Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure chart plot area layout remains valid when using custom dimensions.
// - Build C# tools that automatically adjust chart layout targets based on
//   runtime validation.
// - Generate or transform PPTX files with reliable chart positioning.
// - Validate and correct chart layouts before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Add a clustered column chart
        var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Define manual layout for the plot area
        chart.PlotArea.AsILayoutable.X = 0.2f;
        chart.PlotArea.AsILayoutable.Y = 0.2f;
        chart.PlotArea.AsILayoutable.Width = 0.7f;
        chart.PlotArea.AsILayoutable.Height = 0.7f;

        // Attempt to set layout target to Outer
        chart.PlotArea.LayoutTargetType = LayoutTargetType.Outer;
        chart.ValidateChartLayout();

        // Fallback to Inner if dimensions become negative
        if (chart.PlotArea.ActualWidth < 0 || chart.PlotArea.ActualHeight < 0)
        {
            chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
            chart.ValidateChartLayout();
        }

        // Save the presentation
        try
        {
            presentation.Save("LayoutFallback.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
        finally
        {
            presentation.Dispose();
        }
    }
}
