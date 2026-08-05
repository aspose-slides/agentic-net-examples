// -----------------------------------------------------------------------------
// Example: Hide horizontal axis on line chart using C#
//
// Description:
// Demonstrates how to hide the horizontal (category) axis of a line chart in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a new presentation, adds a line chart, disables the visibility of
// the horizontal axis, and saves the result as a PPTX file. This pattern can be
// used to automate PPTX workflows, validate chart configurations, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hide, Horizontal, Axis, Line,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate hiding the horizontal axis on line charts in PPTX files.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate chart appearance before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 500f, 400f);

        // Hide the horizontal (category) axis
        chart.Axes.HorizontalAxis.IsVisible = false;

        // Save the presentation
        try
        {
            presentation.Save("HideHorizontalAxis.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other save error
        }
    }
}
