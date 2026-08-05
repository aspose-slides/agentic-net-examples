// -----------------------------------------------------------------------------
// Example: Set logarithmic scale on chart axis using C#
//
// Description:
// Demonstrates how to set a logarithmic scale on a chart's vertical axis using
// C# and Aspose.Slides for .NET. The example creates a presentation, adds a
// clustered column chart, configures the vertical axis to use a logarithmic
// scale with a base of 10, and saves the file as a PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Logarithmic, Scale, Chart,
// Axis, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting a logarithmic scale on chart axes.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized chart settings.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

            // Set chart title (optional)
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Logarithmic Scale Example");

            // Configure the vertical axis to use a logarithmic scale
            IAxis verticalAxis = chart.Axes.VerticalAxis;
            verticalAxis.IsLogarithmic = true;
            // Set the logarithmic base (default is 10)
            verticalAxis.LogBase = 10.0;

            // Save the presentation and handle unsupported format exception
            try
            {
                pres.Save("LogarithmicChart.pptx", SaveFormat.Pptx);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("Unsupported format: " + ex.Message);
            }
        }
    }
}
