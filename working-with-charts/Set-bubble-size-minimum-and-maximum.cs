// -----------------------------------------------------------------------------
// Example: Set bubble size minimum and maximum using C#
//
// Description:
// Demonstrates how to set bubble size minimum and maximum using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble, Size, Minimum, Maximum, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting bubble size minimum and maximum.
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
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a bubble chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.Bubble, 50f, 50f, 500f, 400f);

            // Set the bubble size minimum and maximum (example values)
            chart.ChartData.SeriesGroups[0].BubbleSizeMin = 10; // Minimum bubble size
            chart.ChartData.SeriesGroups[0].BubbleSizeMax = 30; // Maximum bubble size

            // Save the presentation
            presentation.Save("BubbleChartMinMax.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
