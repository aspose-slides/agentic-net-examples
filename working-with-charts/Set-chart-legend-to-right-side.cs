// -----------------------------------------------------------------------------
// Example: Set chart legend to right side using C#
//
// Description:
// Demonstrates how to set a chart's legend to the right side using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a clustered 
// column chart, ensures the legend is visible, positions it on the right, and 
// saves the result as a PPTX file. This pattern can be used to automate PPTX 
// workflows, validate results, or integrate presentation logic into .NET 
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Right Side, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart legend to the right side.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Ensure the chart has a legend
            chart.HasLegend = true;

            // Position the legend on the right side of the chart
            chart.Legend.Position = LegendPositionType.Right;

            // Save the presentation to disk
            pres.Save("ChartLegendRight.pptx", SaveFormat.Pptx);
        }
    }
}
