// -----------------------------------------------------------------------------
// Example: Add data table to chart font size using C#
//
// Description:
// Demonstrates how to enable a data table for a chart and set its font size
// using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, shows the data table, customizes the table
// font height for readability, and saves the result as a PPTX file.
// This pattern can be used to automate chart formatting in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Table, Font Size,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a data table to a chart and adjusting its font size.
// - Build C# utilities for PowerPoint chart styling.
// - Generate or modify PPTX files with customized chart data tables.
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
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Charts.IChart chart = slide.Shapes.AddChart(
                Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Enable the data table for the chart
            chart.HasDataTable = true;

            // Customize the font size of the data table for better readability
            chart.ChartDataTable.TextFormat.PortionFormat.FontHeight = 14f;

            // Save the presentation
            presentation.Save("ChartWithDataTable.pptx", SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors (e.g., unsupported format)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
