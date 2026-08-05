// -----------------------------------------------------------------------------
// Example: Insert chart legend with custom font size using C#
//
// Description:
// Demonstrates how to insert a chart legend with a custom font size using C# 
// and Aspose.Slides for .NET. The example creates a new presentation, adds a 
// clustered column chart, enables the legend, sets the legend text font height 
// to 14 points, and saves the presentation as a PPTX file. This pattern can be 
// used to automate PowerPoint chart styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Chart, Legend, Custom Font Size, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of chart legends with specific font sizes.
// - Build C# utilities for PowerPoint chart formatting.
// - Generate or modify PPTX files programmatically in .NET.
// - Ensure consistent chart appearance across presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
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

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Ensure the legend is displayed
            chart.HasLegend = true;

            // Set custom font size for the legend text
            chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

            // Save the presentation
            presentation.Save("ChartWithCustomLegend.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
