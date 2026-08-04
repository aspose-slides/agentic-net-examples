// -----------------------------------------------------------------------------
// Example: Enable automatic bubble size scaling using C#
//
// Description:
// Demonstrates how to enable automatic bubble size scaling for a bubble chart
// using Aspose.Slides for .NET. The example creates a new presentation, adds a
// bubble chart, sets the BubbleSizeScale property to increase bubble sizes
// proportionally, and saves the result as a PPTX file. This pattern can be used
// to programmatically control bubble size scaling in PowerPoint charts.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble Chart, Automatic Scaling,
// BubbleSizeScale, ChartData, Presentation Processing, Office Automation
//
// Use Cases:
// - Apply custom bubble size scaling to charts in automated PPTX generation.
// - Build .NET tools that modify chart appearance for reporting or analytics.
// - Integrate bubble chart scaling into presentation workflows.
// - Ensure consistent visual scaling across multiple presentations.
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
            IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50f, 50f, 600f, 400f);

            // Enable automatic scaling of bubble sizes based on the data range
            chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150; // Scale to 150% of default size

            // Save the presentation
            string outputPath = "BubbleChartScaling.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
