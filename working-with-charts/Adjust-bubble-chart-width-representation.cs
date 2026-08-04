// -----------------------------------------------------------------------------
// Example: Adjust bubble chart width representation using C#
//
// Description:
// Demonstrates how to set a bubble chart's size representation to width using
// Aspose.Slides for .NET. The example creates a new presentation, adds a bubble
// chart, configures the bubble size representation to Width, and saves the
// result as a PPTX file. This pattern can be used to customize bubble chart
// appearance in automated PowerPoint generation scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Adjust, Bubble, Chart, Width,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting bubble chart width representation.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized bubble charts.
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
            IChart chart = presentation.Slides[0].Shapes.AddChart(Charts.ChartType.Bubble, 50f, 50f, 500f, 400f);
            chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = Charts.BubbleSizeRepresentationType.Width;
            presentation.Save("BubbleChartWidth.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
