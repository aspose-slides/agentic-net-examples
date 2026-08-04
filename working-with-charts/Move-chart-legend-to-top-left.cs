// -----------------------------------------------------------------------------
// Example: Move chart legend to top left using C#
//
// Description:
// Demonstrates how to move a chart legend to the top‑left corner of a chart
// using C# and Aspose.Slides for .NET. The example creates a new presentation,
// adds a clustered column chart, positions the legend with custom coordinates,
// and saves the result as a PPTX file. This pattern can be used to automate
// legend placement in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Move, Chart, Legend, Top Left,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically reposition chart legends to the top left.
// - Build .NET tools that modify chart layouts in PPTX files.
// - Generate presentations with custom legend placement.
// - Validate and test chart formatting before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(
            ChartType.ClusteredColumn,
            50f,   // X position
            50f,   // Y position
            500f,  // Width
            400f   // Height
        );

        // Move the legend to the top left corner using custom coordinates
        chart.Legend.X = 0f;                     // X as fraction of chart width
        chart.Legend.Y = 0f;                     // Y as fraction of chart height
        chart.Legend.Width = 0.2f;               // Width as fraction of chart width
        chart.Legend.Height = 0.2f;              // Height as fraction of chart height
        chart.Legend.Position = LegendPositionType.Top; // Optional enum position

        // Save the presentation
        try
        {
            presentation.Save("LegendTopLeft.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle cases where the format is not supported
            // Format not supported: ex.Message
        }
    }
}
