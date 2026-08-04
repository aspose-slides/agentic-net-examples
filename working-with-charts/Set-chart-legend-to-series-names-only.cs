// -----------------------------------------------------------------------------
// Example: Set chart legend to series names only using C#
//
// Description:
// Demonstrates how to set a chart legend to display only the series names using
// C# and Aspose.Slides for .NET. The example creates a presentation, adds a
// clustered column chart, ensures the legend is visible, positions it on the
// right side, and saves the result. This pattern can be used to automate PPTX
// workflows that require chart legends to reflect series names exclusively.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Series Names,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart legends to show series names only.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized chart legends in .NET
//   applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace SetChartLegend
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

                // Ensure the legend is visible
                chart.HasLegend = true;

                // Optionally set legend position (right side)
                chart.Legend.Position = LegendPositionType.Right;

                // Save the presentation
                pres.Save("ChartLegendSeriesNames.pptx", SaveFormat.Pptx);
            }
        }
    }
}
