// -----------------------------------------------------------------------------
// Example: Set decorative line begin short end long using C#
//
// Description:
// Demonstrates how to create a line shape with a short oval begin arrowhead and a long triangle end arrowhead, configure line style, width, dash pattern, and fill color using Aspose.Slides for .NET. The example creates a new presentation, adds the formatted line to the first slide, and saves the file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Decorative line, Begin arrowhead short, End arrowhead long, Line formatting, Presentation processing
//
// Use Cases:
// - Automate creation of lines with specific decorative arrowheads in PPTX files.
// - Build .NET tools for customizing shape appearance in PowerPoint presentations.
// - Generate or modify presentations with precise line styling for reports or diagrams.
// - Validate line formatting logic in automated slide generation workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add an arrow-shaped line to the slide
        IAutoShape line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
        line.LineFormat.Style = LineStyle.ThickBetweenThin;
        line.LineFormat.Width = 10;
        line.LineFormat.DashStyle = LineDashStyle.DashDot;
        line.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
        line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;
        line.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
        line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
        line.LineFormat.FillFormat.FillType = FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Maroon;

        // Define output path
        string outputPath = "ArrowLine.pptx";

        // Save the presentation with exception handling
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
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
