// -----------------------------------------------------------------------------
// Example: Handle unsupported layouttargettype argumentexception using C#
//
// Description:
// Demonstrates how to handle an unsupported LayoutTargetType argument exception 
// using C# and Aspose.Slides for .NET. The example creates a presentation, adds a 
// clustered column chart, manually configures the plot area layout, and then 
// attempts to assign an invalid LayoutTargetType value, catching the resulting 
// ArgumentException. This pattern helps developers safely work with chart layout 
// settings and gracefully handle invalid enum values.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Handle, Unsupported, 
// LayoutTargetType, ArgumentException, Presentation Processing, 
// Office Automation
//
// Use Cases:
// - Automate handling of unsupported LayoutTargetType values.
// - Build C# tools for robust PowerPoint chart manipulation.
// - Ensure graceful error handling in PPTX automation workflows.
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
        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 20f, 100f, 600f, 400f);
        // Manually set plot area layout
        chart.PlotArea.AsILayoutable.X = 0.2f;
        chart.PlotArea.AsILayoutable.Y = 0.2f;
        chart.PlotArea.AsILayoutable.Width = 0.7f;
        chart.PlotArea.AsILayoutable.Height = 0.7f;
        // Attempt to set an unsupported LayoutTargetType value
        try
        {
            chart.PlotArea.LayoutTargetType = (Aspose.Slides.Charts.LayoutTargetType)999;
        }
        catch (ArgumentException ex)
        {
            // Handle unsupported enum value
            Console.WriteLine("Unsupported LayoutTargetType value: " + ex.Message);
        }
        // Save the presentation
        string outputPath = "SetLayoutMode_Output.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
