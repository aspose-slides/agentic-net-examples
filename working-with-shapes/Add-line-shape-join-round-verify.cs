// -----------------------------------------------------------------------------
// Example: Add line shape join round verify using C#
//
// Description:
// Demonstrates how to add a line shape with a round join style and verify it
// using C# and Aspose.Slides for .NET. The example creates a presentation,
// inserts a line shape, sets its line width and join style to Round, prints the
// applied join style to the console, and saves the presentation as a PPTX file.
// This pattern can be used to automate PowerPoint line formatting and validation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line, Shape, Join, Round, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding line shapes with specific join styles.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate line formatting in presentations before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "LineJoinStyleRound.pptx";

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Set line width
        line.LineFormat.Width = 5;

        // Set the line join style to Round
        line.LineFormat.JoinStyle = LineJoinStyle.Round;

        // Verify the join style by printing it
        Console.WriteLine("Line JoinStyle: " + line.LineFormat.JoinStyle);

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}
