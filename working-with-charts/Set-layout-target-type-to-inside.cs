// -----------------------------------------------------------------------------
// Example: Set layout target type to inside using C#
//
// Description:
// Demonstrates how to set the layout target type of a chart's plot area to
// inside (Inner) using C# and Aspose.Slides for .NET. The example creates a
// presentation, adds a clustered column chart, manually defines the plot area
// layout, sets the LayoutTargetType to Inner to exclude axes from the layout
// region, and saves the result as a PPTX file. This pattern helps developers
// automate chart layout adjustments in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, PlotArea, LayoutTargetType,
// Inside, Inner, Presentation Processing, Office Automation
//
// Use Cases:
// - Adjust chart plot area layout to exclude axes.
// - Build C# tools for precise chart formatting in PowerPoint presentations.
// - Generate or modify PPTX files with custom chart layouts in .NET applications.
// - Validate chart layout configurations before publishing.
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
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);

        // Manually define the plot area layout
        chart.PlotArea.AsILayoutable.X = 0.2f;
        chart.PlotArea.AsILayoutable.Y = 0.2f;
        chart.PlotArea.AsILayoutable.Width = 0.7f;
        chart.PlotArea.AsILayoutable.Height = 0.7f;

        // Set layout target type to Inner (exclude axes from layout region)
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;

        // Save the presentation
        presentation.Save("ChartLayoutTargetInner.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}
