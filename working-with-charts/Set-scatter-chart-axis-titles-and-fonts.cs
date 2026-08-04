// -----------------------------------------------------------------------------
// Example: Set scatter chart axis titles and fonts using C#
//
// Description:
// Demonstrates how to add a scatter chart with markers to a PowerPoint slide
// and set custom titles and font styles for both horizontal and vertical axes
// using Aspose.Slides for .NET. The example creates a new presentation, configures
// the chart axis titles, saves the file, and disposes resources.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Scatter, Chart, Axis, Titles, Fonts,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting scatter chart axis titles and font styling in PPTX files.
// - Build .NET tools for customizing chart appearance in presentations.
// - Generate or modify PowerPoint presentations with specific chart formatting.
// - Validate chart axis configurations before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a scatter chart with markers
            IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 50f, 50f, 500f, 400f);

            // Ensure axis titles are visible
            chart.Axes.HorizontalAxis.HasTitle = true;
            chart.Axes.VerticalAxis.HasTitle = true;

            // Set X axis title and font properties
            IChartTitle xAxisTitle = chart.Axes.HorizontalAxis.Title;
            xAxisTitle.AddTextFrameForOverriding("X Axis Title");
            xAxisTitle.TextFormat.PortionFormat.FontHeight = 14f;
            xAxisTitle.TextFormat.PortionFormat.FontBold = NullableBool.True;

            // Set Y axis title and font properties
            IChartTitle yAxisTitle = chart.Axes.VerticalAxis.Title;
            yAxisTitle.AddTextFrameForOverriding("Y Axis Title");
            yAxisTitle.TextFormat.PortionFormat.FontHeight = 14f;
            yAxisTitle.TextFormat.PortionFormat.FontBold = NullableBool.True;

            // Save the presentation
            presentation.Save("ScatterChartAxisTitles.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
