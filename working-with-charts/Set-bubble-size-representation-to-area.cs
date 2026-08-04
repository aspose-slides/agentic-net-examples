// -----------------------------------------------------------------------------
// Example: Set bubble size representation to area using C#
//
// Description:
// Demonstrates how to set bubble size representation to area using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble, Size, Representation, 
// Area, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set bubble size representation to area.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Presentation presentation = new Presentation();
            IChart chart = presentation.Slides[0].Shapes.AddChart(Charts.ChartType.Bubble, 50f, 50f, 600f, 400f);
            // Set bubble size representation to Area for all series
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Charts.BubbleSizeRepresentationType.Area;
            presentation.Save("BubbleChartArea.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle exceptions (e.g., format not supported, file I/O errors)
        }
    }
}
