// -----------------------------------------------------------------------------
// Example: Enable minor gridlines on value axis using C#
//
// Description:
// Demonstrates how to enable minor gridlines on the value axis of a chart in a
// PowerPoint presentation using Aspose.Slides for .NET. The example creates a
// new presentation, adds an Area chart, validates the chart layout, sets the
// minor gridlines on the vertical (value) axis to be visible, and saves the
// presentation as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, Minor, Gridlines, Value,
// Axis, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enabling minor gridlines on the value axis of charts.
// - Build C# tools for PowerPoint chart customization.
// - Generate or modify PPTX files with specific chart formatting in .NET
//   applications.
// - Validate chart appearance programmatically before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Define output path
            string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "EnableMinorGridlines.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add an Area chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Area, 50f, 50f, 500f, 400f);

            // Validate layout to ensure axis values are calculated
            chart.ValidateChartLayout();

            // Enable minor gridlines on the vertical (value) axis by setting a visible fill type
            chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;

            // Save the presentation
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
