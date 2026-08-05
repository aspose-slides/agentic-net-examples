// -----------------------------------------------------------------------------
// Example: Add line shape cap round verify using C#
//
// Description:
// Demonstrates how to add a line shape with a round cap style using C# and
// Aspose.Slides for .NET. The example creates a new presentation, inserts a
// line shape, sets its cap style to round for visual verification, and saves
// the result as a PPTX file. This pattern can be used to automate shape styling
// tasks, validate rendering of line caps, or integrate presentation generation
// into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line, Shape, Cap, Round, Verify,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding line shapes with specific cap styles.
// - Build C# tools for PowerPoint presentation processing and styling.
// - Generate or transform PPTX files with customized line appearances.
// - Verify visual properties of shapes before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Presentation();

        // Access the first slide
        var slide = presentation.Slides[0];

        // Add a line shape to the slide
        var line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Set the line cap style to round for visual appearance
        line.LineFormat.CapStyle = LineCapStyle.Round;
        line.LineFormat.Width = 5; // Make the line visible

        // Save the presentation
        string outputPath = "LineCapRound.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}
