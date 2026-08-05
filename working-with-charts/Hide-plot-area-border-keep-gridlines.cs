// -----------------------------------------------------------------------------
// Example: Hide plot area border keep gridlines using C#
//
// Description:
// Demonstrates how to hide the plot area border while preserving gridlines in a
// chart using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, removes the plot area border by setting its
// line width to zero, and saves the file. This pattern can be used to customize
// chart appearance in automated PowerPoint processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide Plot Area Border, Gridlines,
// Chart Formatting, Presentation Processing, Office Automation
//
// Use Cases:
// - Remove plot area borders from charts while keeping gridlines visible.
// - Automate chart styling in bulk PowerPoint files.
// - Build .NET tools for customizing chart appearance in presentations.
// - Ensure consistent visual formatting across generated PPTX reports.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Hide the plot area border by setting its line width to zero
            chart.PlotArea.Format.Line.Width = 0;

            // Gridlines are retained by default; no changes required

            // Save the presentation
            try
            {
                pres.Save("HidePlotAreaBorder.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}
