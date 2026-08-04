// -----------------------------------------------------------------------------
// Example: Set layout target type to outside using C#
//
// Description:
// Demonstrates how to set layout target type to outside using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Layout, Target, Type, Outside, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set layout target type to outside.
// - Build C# tools for chart layout processing.
// - Generate or transform PPTX files with specific chart layouts in .NET applications.
// - Validate chart layout workflows before publishing or integration.
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
