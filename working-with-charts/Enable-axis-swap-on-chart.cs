// -----------------------------------------------------------------------------
// Example: Enable axis swap on chart using C#
//
// Description:
// Demonstrates how to enable axis swap on a chart using C# and Aspose.Slides for 
// .NET. The example creates a new presentation, adds a clustered column chart, 
// swaps the X and Y axes, and saves the result as a PPTX file. This pattern can be 
// used to automate chart axis manipulation in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, Axis, Swap, Chart, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate swapping axes on charts in presentations.
// - Build C# tools for PowerPoint chart manipulation.
// - Generate or transform PPTX files with modified chart axes.
// - Validate chart configurations before publishing.
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

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

            // Swap data between the X and Y axes
            chart.ChartData.SwitchRowColumn();

            // Save the presentation
            string outputPath = "SwapAxesChart.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
