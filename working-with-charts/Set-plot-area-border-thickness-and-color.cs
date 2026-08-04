// -----------------------------------------------------------------------------
// Example: Set plot area border thickness and color using C#
//
// Description:
// Demonstrates how to set the plot area border thickness and color of a chart
// using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, configures the plot area border, and saves the
// file as a PPTX. This pattern can be used to automate PowerPoint chart styling
// in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Plot Area, Border, Thickness, Color, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting plot area border thickness and color for charts.
// - Build C# utilities for PowerPoint chart formatting.
// - Generate or modify PPTX files with customized chart appearance.
// - Validate chart styling in automated presentation workflows.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetPlotAreaBorder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Set plot area border thickness
                chart.PlotArea.Format.Line.Width = 2f;

                // Set plot area border color to red
                chart.PlotArea.Format.Line.FillFormat.FillType = FillType.Solid;
                chart.PlotArea.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

                // Save the presentation
                presentation.Save("SetPlotAreaBorder.pptx", SaveFormat.Pptx);
            }
        }
    }
}
