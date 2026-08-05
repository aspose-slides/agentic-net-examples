// -----------------------------------------------------------------------------
// Example: Add line shape begin none end diamond using C#
//
// Description:
// Demonstrates how to add a line shape with a 'none' begin arrowhead and a
// 'diamond' end arrowhead using C# and Aspose.Slides for .NET. The example
// creates a new presentation, inserts a line shape onto the first slide,
// configures its arrowhead styles, and saves the result as a PPTX file.
// This pattern can be used to automate PowerPoint presentation creation and
// manipulation in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line, Shape, Begin, None,
// End, Diamond, Arrowhead, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding line shapes with custom arrowheads.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with specific shape styling in .NET.
// - Validate presentation workflows before publishing or integration.
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

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Configure arrowheads: begin none, end diamond
        line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
        line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Diamond;

        // Define output path
        string outputPath = "LineWithDiamondArrow.pptx";

        // Save the presentation with exception handling
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            presentation.Dispose();
        }
    }
}
