// -----------------------------------------------------------------------------
// Example: Enable data table visibility on chart using C#
//
// Description:
// Demonstrates how to enable the data table visibility for a chart in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a new presentation, adds a clustered column chart, turns on the
// data table, and saves the file as a PPTX. This pattern can be used to
// automate chart enhancements in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, Data Table, Visibility,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enabling data table visibility on charts in PPTX files.
// - Build C# utilities for enhancing PowerPoint presentations.
// - Generate or modify chart data tables programmatically.
// - Validate chart formatting before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart with sample data
            IChart chart = slide.Shapes.AddChart(
                ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Enable the data table for the chart
            chart.HasDataTable = true;

            // Define output file path
            string outputPath = "ChartWithDataTable.pptx";

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
