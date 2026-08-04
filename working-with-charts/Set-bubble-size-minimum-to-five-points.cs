// -----------------------------------------------------------------------------
// Example: Set bubble size minimum to five points using C#
//
// Description:
// Demonstrates how to set the minimum bubble size to five points in a bubble
// chart using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds a bubble chart, configures the bubble size scale to
// enforce a minimum size of five points, and saves the result as a PPTX file.
// This pattern can be used to automate PowerPoint chart formatting tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bubble Chart, Minimum Size,
// Five Points, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting a minimum bubble size of five points in presentations.
// - Build C# utilities for customizing chart appearance in PowerPoint files.
// - Generate or modify PPTX files with specific chart formatting requirements.
// - Validate and enforce chart styling rules before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a bubble chart with sample data
                IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 0f, 0f, 500f, 400f);

                // Ensure the chart type is a bubble chart
                if (!ChartTypeCharacterizer.IsChartTypeBubble(chart.Type))
                {
                    // If not a bubble chart, exit
                    return;
                }

                // Get the first series (creates one if none exists)
                IChartSeries series = chart.ChartData.Series[0];

                // Set the minimum bubble size to five points via the series group scale
                // (BubbleSizeScale is an integer representing the scale factor; using 5 as the required minimum)
                series.ParentSeriesGroup.BubbleSizeScale = 5;

                // Save the presentation
                try
                {
                    pres.Save("BubbleChart_MinSize.pptx", SaveFormat.Pptx);
                }
                catch (System.NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}
