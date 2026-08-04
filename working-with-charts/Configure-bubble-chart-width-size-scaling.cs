// -----------------------------------------------------------------------------
// Example: Configure bubble chart width size scaling using C#
//
// Description:
// Demonstrates how to configure bubble chart width size scaling using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Bubble, Chart, 
// Width, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate configure bubble chart width size scaling.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a bubble chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 500f, 400f);

        // Set bubble size representation to Width for proportional scaling
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;

        // Save the presentation
        string outputPath = "BubbleChart.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}
