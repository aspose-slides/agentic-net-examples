// -----------------------------------------------------------------------------
// Example: Set chart legend top left using C#
//
// Description:
// Demonstrates how to position a chart legend at the top‑left corner of a
// chart using Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, moves the legend to coordinates (0,0) within
// the chart area, sets its size, and saves the result as a PPTX file.
// This pattern can be used to customize chart legends in automated PPTX
// generation or processing scenarios.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, Legend, Position, TopLeft,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically set chart legend position to top‑left.
// - Customize legend size and placement in generated presentations.
// - Build .NET tools for PowerPoint chart formatting.
// - Automate PPTX creation with specific chart layout requirements.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using AspNet.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 150f, 500f, 400f);

        // Move the legend to the top‑left corner of the chart
        chart.Legend.X = 0f;
        chart.Legend.Y = 0f;
        chart.Legend.Width = 100f;   // set desired width
        chart.Legend.Height = 50f;   // set desired height

        // Save the presentation
        presentation.Save("LegendTopLeft.pptx", SaveFormat.Pptx);
    }
}
