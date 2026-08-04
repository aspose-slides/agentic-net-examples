// -----------------------------------------------------------------------------
// Example: Set chart legend bottom right using C#
//
// Description:
// Demonstrates how to position a chart legend at the bottom‑right corner of a
// chart using Aspose.Slides for .NET. The example creates a presentation, adds a
// clustered column chart, sets the legend location using relative coordinates,
// and saves the result as a PPTX file. This pattern can be used to automate
// legend placement in PowerPoint charts.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Bottom Right,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically position chart legends at the bottom‑right.
// - Build .NET tools for customizing PowerPoint chart layouts.
// - Generate or modify PPTX files with specific legend positioning.
// - Validate chart appearance in automated presentation workflows.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Set legend position to bottom‑right using custom coordinates
            chart.Legend.X = 0.7f;      // X position as fraction of chart width
            chart.Legend.Y = 0.9f;      // Y position as fraction of chart height
            chart.Legend.Width = 0.2f;  // Width as fraction of chart width
            chart.Legend.Height = 0.1f; // Height as fraction of chart height

            // Save the presentation
            presentation.Save("LegendBottomRight.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.NotSupportedException)
        {
            // Format not supported
        }
        catch (System.Exception)
        {
            // Handle other exceptions (e.g., file I/O, licensing)
        }
    }
}
