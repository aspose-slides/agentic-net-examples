// -----------------------------------------------------------------------------
// Example: Hide chart title keep axis labels using C#
//
// Description:
// Demonstrates how to hide a chart title while preserving axis labels in a
// PowerPoint presentation using Aspose.Slides for .NET. The example creates a
// new presentation, adds a clustered column chart, disables the chart title,
// and saves the result as a PPTX file. This pattern can be used to customize
// chart appearance programmatically.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide Chart Title, Keep Axis Labels,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically remove chart titles without affecting axis labels.
// - Build .NET tools for customizing chart visuals in PowerPoint files.
// - Automate PPTX generation with specific chart formatting requirements.
// - Validate chart appearance before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "HideChartTitle.pptx";

        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart with sample data
            var chart = slide.Shapes.AddChart(Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Hide the chart title while keeping axis labels visible
            chart.HasTitle = false;

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported: comment placeholder
            // Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
