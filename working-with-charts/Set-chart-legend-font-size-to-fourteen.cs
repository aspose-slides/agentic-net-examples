// -----------------------------------------------------------------------------
// Example: Set chart legend font size to fourteen using C#
//
// Description:
// Demonstrates how to set the legend font size of a chart to fourteen points
// using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, modifies the legend font size, and saves the
// file as a PPTX. This pattern can be used to automate PowerPoint chart
// formatting tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Font, Size,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting chart legend font size to fourteen points.
// - Build C# utilities for PowerPoint chart formatting.
// - Generate or modify PPTX files programmatically in .NET.
// - Ensure consistent chart appearance across presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace LegendFontSizeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

            // Set the overall legend font size to 14 points
            chart.Legend.TextFormat.PortionFormat.FontHeight = 14f;

            try
            {
                // Save the presentation
                presentation.Save("LegendFontSize.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format exception
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
