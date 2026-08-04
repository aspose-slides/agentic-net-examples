// -----------------------------------------------------------------------------
// Example: Add data table below chart with custom font sizes using C#
//
// Description:
// Demonstrates how to add a data table below a chart and customize the font
// sizes of both the chart text and the data table using Aspose.Slides for .NET.
// The example creates a presentation, inserts a clustered column chart, sets
// the chart's overall font size, enables the data table, adjusts its font size,
// and saves the result as a PPTX file. This pattern can be used to automate
// PowerPoint chart formatting tasks in .NET applications.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, Data Table, Font Size, Presentation
// Processing, Office Automation
//
// Use Cases:
// - Add a data table below a chart with specific font styling.
// - Build tools to standardize chart appearance in PowerPoint files.
// - Generate or modify PPTX presentations programmatically in .NET.
// - Ensure consistent typography for charts and their data tables.
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
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Set the chart's overall font size for readability
        chart.TextFormat.PortionFormat.FontHeight = 14f;

        // Enable the data table below the chart
        chart.HasDataTable = true;

        // Customize the data table's font size
        chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 12f;

        // Save the presentation
        presentation.Save("ChartWithDataTable.pptx", SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}
