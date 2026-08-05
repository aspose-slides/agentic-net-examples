// -----------------------------------------------------------------------------
// Example: Set chart legend to bottom horizontal using C#
//
// Description:
// Demonstrates how to set a chart's legend to a bottom horizontal position using
// C# and Aspose.Slides for .NET. The example creates a presentation, adds a
// clustered column chart, configures the legend to appear below the chart in a
// non‑overlay (horizontal) layout, and saves the result as a PPTX file.
// This pattern can be used to automate legend positioning in PowerPoint
// presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Bottom, Horizontal,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart legend to bottom horizontal in PPTX files.
// - Build C# utilities for PowerPoint chart formatting.
// - Generate or modify presentations with specific legend layouts.
// - Validate chart appearance programmatically before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50, 50, 500, 400);

            // Ensure the chart displays a legend
            chart.HasLegend = true;

            // Position the legend at the bottom of the chart
            chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.Bottom;

            // Set overlay to false for a horizontal layout (legend below the chart)
            chart.Legend.Overlay = false;

            // Save the presentation to a file
            presentation.Save("ChartLegendBottomHorizontal.pptx", SaveFormat.Pptx);
        }
    }
}
