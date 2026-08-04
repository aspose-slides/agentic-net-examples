// -----------------------------------------------------------------------------
// Example: Set bubble chart minimum size five points using C#
//
// Description:
// Demonstrates how to set bubble chart minimum size five points using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble, Chart, Minimum, Size, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set bubble chart minimum size five points.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a bubble chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Bubble,
            50,   // X position
            50,   // Y position
            500,  // Width
            400   // Height
        );

        // Set the bubble size scale to ensure a minimum bubble size of five points
        chart.ChartData.SeriesGroups[0].BubbleSizeScale = 5;

        // Save the presentation
        presentation.Save("BubbleChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
