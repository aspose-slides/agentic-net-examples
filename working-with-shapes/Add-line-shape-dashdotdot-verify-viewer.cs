// -----------------------------------------------------------------------------
// Example: Add line shape dashdotdot verify viewer using C#
//
// Description:
// Demonstrates how to add a line shape with a dash‑dot‑dot line style to a slide
// using Aspose.Slides for .NET and save the presentation so it can be viewed in
// PowerPoint. The example creates a new presentation, inserts a line shape,
// applies the LargeDashDotDot dash style, and saves the file as PPTX.
// This pattern can be used to automate shape styling and verify rendering in
// PowerPoint viewers.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line Shape, Dashdotdot, 
// LineDashStyle, Presentation Generation, Office Automation
//
// Use Cases:
// - Add line shapes with specific dash styles to presentations.
// - Generate PPTX files programmatically for reporting or documentation.
// - Verify that styled shapes render correctly in PowerPoint viewers.
// - Integrate shape styling into .NET automation tools.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "LineDashStyleDemo.pptx";
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a line shape to the slide
            IAutoShape line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

            // Set the line dash style to dash‑dot‑dot
            line.LineFormat.DashStyle = LineDashStyle.LargeDashDotDot;

            // Save the presentation (PowerPoint viewer can render it)
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format or file I/O issues
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
