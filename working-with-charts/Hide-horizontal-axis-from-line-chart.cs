// -----------------------------------------------------------------------------
// Example: Hide horizontal axis from line chart using C#
//
// Description:
// Demonstrates how to hide the horizontal (category) axis of a line chart using
// C# and Aspose.Slides for .NET. The example creates a new presentation, adds a
// line chart, disables the visibility of the horizontal axis, and saves the
// result as a PPTX file. This pattern can be used to automate PowerPoint chart
// customizations, validate presentation output, or integrate chart processing
// into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Horizontal, Axis, Line Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate hiding the horizontal axis in line charts within PPTX files.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Generate or modify PPTX presentations programmatically in .NET.
// - Validate chart configurations before publishing or further processing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace HideHorizontalAxisExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Line, 50f, 50f, 500f, 400f);

            // Hide the horizontal (category) axis
            chart.Axes.HorizontalAxis.IsVisible = false;

            // Save the presentation
            try
            {
                presentation.Save("HideHorizontalAxis.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions (e.g., I/O errors)
            }
        }
    }
}
