// -----------------------------------------------------------------------------
// Example: Configure vertical axis logarithmic scale using C#
//
// Description:
// Demonstrates how to configure the vertical (value) axis of a chart to use a
// logarithmic scale using C# and Aspose.Slides for .NET. The example creates a
// new presentation, adds an Area chart, sets the vertical axis to logarithmic
// mode (with an optional base), and saves the result as a PPTX file. This
// pattern can be used to automate PPTX chart formatting, validate axis
// settings, or integrate chart manipulation into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Axis, Logarithmic,
// Scale, Vertical Axis, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate configuring vertical axis logarithmic scale in charts.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized chart axes in .NET
//   applications.
// - Validate chart axis settings before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add an Area chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.Area, 50f, 50f, 500f, 400f);

            // Configure the vertical (value) axis to use a logarithmic scale
            chart.Axes.VerticalAxis.IsLogarithmic = true;
            // Optionally set the logarithmic base (default is 10)
            chart.Axes.VerticalAxis.LogBase = 10.0;

            // Save the presentation
            presentation.Save("LogarithmicAxisChart.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
