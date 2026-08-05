// -----------------------------------------------------------------------------
// Example: Get chart legend position and log using C#
//
// Description:
// Demonstrates how to create a presentation, add a clustered column chart,
// retrieve the chart legend position, and log it using C# and Aspose.Slides for .NET.
// The example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Position,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate retrieval of chart legend position and logging.
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
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            50f, 50f, 400f, 300f);

        // Validate layout to ensure actual values are up‑to‑date
        chart.ValidateChartLayout();

        // Retrieve the current legend position
        Aspose.Slides.Charts.LegendPositionType legendPosition = chart.Legend.Position;

        // Log the legend position for debugging
        Console.WriteLine("Current legend position: " + legendPosition.ToString());

        // Save the presentation
        try
        {
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
