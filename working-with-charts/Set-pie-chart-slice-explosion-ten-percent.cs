// -----------------------------------------------------------------------------
// Example: Set pie chart slice explosion ten percent using C#
//
// Description:
// Demonstrates how to set pie chart slice explosion to ten percent using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Pie Chart, Slice, Explosion, 
// Percent, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting pie chart slice explosion to ten percent.
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
        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a pie chart to the slide
        IChart chart = slide.Shapes.AddChart(
            ChartType.Pie,
            50,   // X position
            50,   // Y position
            400,  // Width
            400   // Height
        );

        // Set explosion (slice distance) to 10% for highlighted data points
        // Assuming the chart has at least two data points
        chart.ChartData.Series[0].DataPoints[0].Explosion = 10;
        chart.ChartData.Series[0].DataPoints[1].Explosion = 10;

        // Save the presentation
        pres.Save("PieChartExplosion.pptx", SaveFormat.Pptx);
    }
}
