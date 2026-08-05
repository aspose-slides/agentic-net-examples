// -----------------------------------------------------------------------------
// Example: Set chart legend to top right using C#
//
// Description:
// Demonstrates how to set a chart's legend position to the top right corner 
// using C# and Aspose.Slides for .NET. The example creates a new presentation, 
// adds a clustered column chart, enables its legend, moves the legend to the 
// top‑right position, and saves the result as a PPTX file. This pattern can be 
// used to automate PowerPoint chart formatting in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, TopRight, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart legend to top right in PPTX files.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Generate or modify charts programmatically in .NET applications.
// - Validate and test chart layout configurations before publishing.
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
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Ensure the chart has a legend
        chart.HasLegend = true;

        // Position the legend at the top right corner
        chart.Legend.Position = LegendPositionType.TopRight;

        // Save the presentation
        try
        {
            pres.Save("ChartLegendTopRight.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle format not supported or other errors
        }
    }
}
