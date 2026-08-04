// -----------------------------------------------------------------------------
// Example: Set chart legend to bottom right using C#
//
// Description:
// Demonstrates how to set a chart legend to the bottom‑right corner using C# 
// and Aspose.Slides for .NET. The example shows the required presentation‑processing 
// steps for PowerPoint files and produces the requested output in a standalone 
// console application. Developers can use this pattern to automate PPTX workflows, 
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Bottom Right, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting a chart legend to the bottom‑right position.
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
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
            // Update legend position to bottom‑right corner
            chart.Legend.Position = LegendPositionType.Custom;
            chart.Legend.X = 1.0f; // right edge (fraction of chart width)
            chart.Legend.Y = 1.0f; // bottom edge (fraction of chart height)
            presentation.Save("LegendBottomRight.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format or external resource errors)
        }
    }
}
