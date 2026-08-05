// -----------------------------------------------------------------------------
// Example: Configure axis label number format with thousands using C#
//
// Description:
// Demonstrates how to configure the horizontal axis label number format to
// include thousand separators using C# and Aspose.Slides for .NET. The example
// creates a presentation, adds a clustered column chart, applies a custom
// number format (“#,##0”) to the horizontal axis, and saves the result as a PPTX
// file. This pattern can be used to automate PowerPoint chart formatting in
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Axis, Label, Number,
// Thousands, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting axis label number format with thousands in charts.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized chart formatting.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ConfigureAxisNumberFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a clustered column chart
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                    // Set custom number format with thousand separators for the horizontal axis
                    chart.Axes.HorizontalAxis.NumberFormat = "#,##0";

                    // Save the presentation
                    presentation.Save("AxisNumberFormat.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions (e.g., file I/O errors)
            }
        }
    }
}
