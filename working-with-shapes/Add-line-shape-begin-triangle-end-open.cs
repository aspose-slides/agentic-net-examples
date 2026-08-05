// -----------------------------------------------------------------------------
// Example: Add line shape begin triangle end open using C#
//
// Description:
// Demonstrates how to add a line shape with a triangular begin arrowhead and an
// open end arrowhead using C# and Aspose.Slides for .NET. The example creates a
// new presentation, inserts a line on the first slide, configures the arrowhead
// styles, and saves the result as a PPTX file. This pattern can be used to
// automate PowerPoint drawing tasks, generate custom diagrams, or integrate
// arrow‑styled lines into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line Shape, Arrowhead, Begin
// Triangle, End Open, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of lines with specific arrowhead styles.
// - Build C# utilities for PowerPoint diagram generation.
// - Generate or modify PPTX files with custom line annotations.
// - Validate arrowhead configurations in presentation workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "ArrowLine.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a line shape to the slide
        IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Set the begin arrow style to Triangle
        line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Triangle;

        // Set the end arrow style to Open
        line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Open;

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}
