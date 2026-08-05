// -----------------------------------------------------------------------------
// Example: Get legend position and log using C#
//
// Description:
// Demonstrates how to retrieve the legend position from a chart and log it
// using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, accesses the chart's legend, outputs its
// position to the console, and saves the presentation. This pattern helps
// developers automate PowerPoint chart analysis, debugging, and validation
// tasks within .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Legend, Position, Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate retrieval and logging of chart legend positions.
// - Build C# utilities for PowerPoint chart inspection and debugging.
// - Generate or modify PPTX files with chart metadata in .NET applications.
// - Validate presentation content before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace LegendPositionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
                chart.ValidateChartLayout();

                // Retrieve the legend and its position
                ILegend legend = chart.Legend;
                LegendPositionType currentPosition = legend.Position;

                // Log the legend position for debugging
                Console.WriteLine("Current legend position: " + currentPosition.ToString());

                // Save the presentation
                string outputPath = "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}
