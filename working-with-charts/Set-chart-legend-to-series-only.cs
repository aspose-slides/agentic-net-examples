// -----------------------------------------------------------------------------
// Example: Set chart legend to series only using C#
//
// Description:
// Demonstrates how to configure a chart's legend to display only series names
// using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, ensures the legend is visible, positions it
// to the right (the default behavior shows only series entries), and saves the
// result as a PPTX file. This pattern can be used to automate PowerPoint
// processing tasks involving chart legends.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Series Only,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart legends to display series names only.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with specific legend configurations.
// - Validate chart legend settings in presentation workflows.
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
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
                // Ensure legend is displayed
                chart.HasLegend = true;
                // Position legend to the right (shows only series names by default)
                chart.Legend.Position = LegendPositionType.Right;
                // Save the presentation before exiting
                pres.Save("ChartLegendSeriesOnly.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unexpected errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
