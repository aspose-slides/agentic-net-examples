// -----------------------------------------------------------------------------
// Example: Set chart legend size width height using C#
//
// Description:
// Demonstrates how to set the width and height of a chart legend using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a clustered 
// column chart, adjusts the legend size relative to the chart dimensions, and 
// saves the result as a PPTX file. This pattern helps automate PowerPoint 
// chart formatting tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Size, Width, Height, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically set chart legend dimensions.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with specific legend sizing.
// - Validate chart layout in automated presentation workflows.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ResizedLegendChart.pptx";
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
            // Resize the legend
            chart.Legend.Width = 0.5f;   // 50% of the chart width
            chart.Legend.Height = 0.2f;  // 20% of the chart height
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
