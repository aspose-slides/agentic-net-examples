// -----------------------------------------------------------------------------
// Example: Set bubble size representation to width proportional using C#
//
// Description:
// Demonstrates how to set bubble size representation to width proportional 
// using C# and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble, Size, Representation, 
// Width, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set bubble size representation to width proportional.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
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
            50f, 50f, 400f, 300f);

        // Set bubble size representation to Width for proportional width scaling
        chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Aspose.Slides.Charts.BubbleSizeRepresentationType.Width;

        // Save the presentation
        presentation.Save("BubbleChartWidthRepresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
