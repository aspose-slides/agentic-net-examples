// -----------------------------------------------------------------------------
// Example: Hide axis lines keep labels visible using C#
//
// Description:
// Demonstrates how to hide both vertical and horizontal axis lines while
// keeping their labels visible using C# and Aspose.Slides for .NET. The example
// creates a presentation, adds a clustered column chart, modifies axis
// formatting, and saves the result as a PPTX file. This pattern can be used to
// automate PowerPoint chart styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Axis, Lines, Keep,
// Labels, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate hiding axis lines while preserving label visibility.
// - Build C# utilities for PowerPoint chart formatting.
// - Generate or transform PPTX files with customized chart axes.
// - Validate chart appearance before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HideAxisLines
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Hide the vertical axis line while keeping its labels visible
                IAxis verticalAxis = chart.Axes.VerticalAxis;
                verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
                verticalAxis.IsVisible = true; // ensure labels stay visible

                // Hide the horizontal axis line while keeping its labels visible
                IAxis horizontalAxis = chart.Axes.HorizontalAxis;
                horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
                horizontalAxis.IsVisible = true; // ensure labels stay visible

                // Save the presentation
                presentation.Save("HideAxisLines.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, web service errors)
                Console.WriteLine(ex.Message);
            }
        }
    }
}
