// -----------------------------------------------------------------------------
// Example: Set chart legend bottom horizontal using C#
//
// Description:
// Demonstrates how to set a chart legend to the bottom (horizontal) position 
// using C# and Aspose.Slides for .NET. The example creates a presentation, 
// adds a clustered column chart, enables the legend, positions it at the 
// bottom of the chart, disables overlay, and saves the result as a PPTX file. 
// This pattern can be used to automate PowerPoint chart formatting tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Bottom, 
// Horizontal, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart legend to bottom horizontal orientation.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or modify PPTX files with customized chart legends in .NET 
//   applications.
// - Validate chart layout workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.Charts.IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
            chart.HasLegend = true;
            chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Bottom;
            chart.Legend.Overlay = false;
            pres.Save("ChartWithBottomLegend.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
