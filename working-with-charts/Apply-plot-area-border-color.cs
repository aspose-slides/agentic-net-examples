// -----------------------------------------------------------------------------
// Example: Apply plot area border color using C#
//
// Description:
// Demonstrates how to apply plot area border color using C# and Aspose.Slides 
// for .NET. The example shows the required presentation-processing steps for 
// PowerPoint files and produces the requested output in a standalone console 
// application. Developers can use this pattern to automate PPTX workflows, 
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Plot, Area, Border, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate apply plot area border color.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartPlotAreaBorderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a clustered column chart to the slide
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Apply a solid fill to the plot area (optional background color)
            chart.PlotArea.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightGray;

            // Set a custom border (line) color for the plot area
            chart.PlotArea.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            chart.PlotArea.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            try
            {
                presentation.Save("ChartWithCustomPlotAreaBorder.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
