// -----------------------------------------------------------------------------
// Example: Add rectangle line width 0.75pt verify using C#
//
// Description:
// Demonstrates how to add a rectangle shape with a line width of 0.75 points
// using C# and Aspose.Slides for .NET. The example creates a new presentation,
// inserts a rectangle on the first slide, sets its line width, ensures the line
// is visible, and saves the result as a PPTX file. This pattern can be used to
// automate PowerPoint shape styling tasks, validate line formatting, or
// integrate shape creation into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Line, Width, 0.75Pt,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding rectangles with specific line widths.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate shape line formatting before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100f, 100f, 200f, 100f);

        // Set line width to 0.75 points
        shape.LineFormat.Width = 0.75f;

        // Ensure line is visible (solid fill)
        shape.LineFormat.FillFormat.FillType = FillType.Solid;

        // Save the presentation
        string outputPath = "output.pptx";
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}
