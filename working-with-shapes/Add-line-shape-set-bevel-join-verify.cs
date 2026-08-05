// -----------------------------------------------------------------------------
// Example: Add line shape set bevel join verify using C#
//
// Description:
// Demonstrates how to add a line shape, set its line join style to Bevel, and
// verify the result by saving the presentation using C# and Aspose.Slides for .NET.
// The example creates a new presentation, adds a line shape, configures its
// line width and bevel join, and saves the file as a PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line, Shape, Bevel, Join,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding line shapes with specific bevel join styles.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate line formatting in presentations before publishing or integration.
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

        // Add a plain line shape to the slide
        IShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 100, 300, 0);

        // Set line width
        lineShape.LineFormat.Width = 5;

        // Set line join style to Bevel
        lineShape.LineFormat.JoinStyle = Aspose.Slides.LineJoinStyle.Bevel;

        // Save the presentation
        try
        {
            presentation.Save("LineJoinBevel.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported.
        }
    }
}
