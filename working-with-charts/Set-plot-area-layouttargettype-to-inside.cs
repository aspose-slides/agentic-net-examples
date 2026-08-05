// -----------------------------------------------------------------------------
// Example: Set plot area layouttargettype to inside using C#
//
// Description:
// Demonstrates how to set the plot area LayoutTargetType to Inner (inside) using
// C# and Aspose.Slides for .NET. The example creates a presentation, adds a
// clustered column chart, defines a manual layout for the plot area, sets the
// layout target type to inside, and saves the file. This pattern can be used to
// control chart layout behavior in PowerPoint automation scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, PlotArea, LayoutTargetType,
// Inner, Inside, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart plot area layout target to inside.
// - Build C# tools for precise chart layout control in PowerPoint files.
// - Generate or modify PPTX files with custom chart positioning.
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
        // Define manual layout for the plot area
        chart.PlotArea.AsILayoutable.X = 0.2f;
        chart.PlotArea.AsILayoutable.Y = 0.2f;
        chart.PlotArea.AsILayoutable.Width = 0.7f;
        chart.PlotArea.AsILayoutable.Height = 0.7f;
        // Set layout target type to Inner (inside, excludes axes)
        chart.PlotArea.LayoutTargetType = Aspose.Slides.Charts.LayoutTargetType.Inner;
        // Save the presentation
        presentation.Save("ChartLayoutTargetInner.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Dispose the presentation
        presentation.Dispose();
    }
}
