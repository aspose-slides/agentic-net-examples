// -----------------------------------------------------------------------------
// Example: Add line shape 3pt weight view using C#
//
// Description:
// Demonstrates how to add a line shape with a 3‑point line weight to a
// presentation using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts a line shape, sets its line width to 3 points, and
// saves the result as a PPTX file. This pattern can be used to automate
// PowerPoint shape creation and styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Line Shape, Line Weight, 3pt,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of line shapes with specific line weight.
// - Build C# utilities for PowerPoint presentation styling.
// - Generate or modify PPTX files programmatically.
// - Validate line formatting in presentation workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Presentation())
            {
                var slide = presentation.Slides[0];
                var line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
                line.LineFormat.Width = 3;
                var outputPath = "LineShape.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception)
        {
            // Handle unsupported format or other errors
        }
    }
}
