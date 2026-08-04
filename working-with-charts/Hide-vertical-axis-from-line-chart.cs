// -----------------------------------------------------------------------------
// Example: Hide vertical axis from line chart using C#
//
// Description:
// Demonstrates how to hide the vertical axis of a line chart in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds a line chart, disables the visibility of its vertical
// axis, and saves the result as a PPTX file. This pattern can be used to
// automate chart formatting tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide Vertical Axis, Line Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically hide the vertical axis of line charts in PPTX files.
// - Build .NET tools for customizing chart appearance in PowerPoint.
// - Automate generation of presentations with specific chart formatting.
// - Validate chart configurations before publishing.
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 500f, 400f);
            chart.Axes.VerticalAxis.IsVisible = false;
            presentation.Save("LineChart_NoVerticalAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
