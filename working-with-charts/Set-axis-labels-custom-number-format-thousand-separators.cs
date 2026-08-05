// -----------------------------------------------------------------------------
// Example: Set axis labels custom number format thousand separators using C#
//
// Description:
// Demonstrates how to set axis labels custom number format thousand separators 
// using C# and Aspose.Slides for .NET. The example creates a presentation, adds a 
// clustered column chart, configures both vertical and horizontal axes to use a 
// thousand‑separator numeric format, and saves the result as a PPTX file. This 
// pattern can be used to automate PowerPoint chart formatting in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Axis, Labels, Custom, Number, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting axis labels custom number format thousand separators.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
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

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(
                ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Configure axis labels to use thousand separator format
            chart.Axes.VerticalAxis.NumberFormat = "#,##0";
            chart.Axes.HorizontalAxis.NumberFormat = "#,##0";

            // Save the presentation
            string outputPath = "ChartAxisNumberFormat.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unexpected errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
