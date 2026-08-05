// -----------------------------------------------------------------------------
// Example: Insert ellipse with long dash to pptx using C#
//
// Description:
// Demonstrates how to insert an ellipse shape with a large dash line style 
// into a PowerPoint presentation using C# and Aspose.Slides for .NET. The 
// example creates a new presentation, adds an ellipse to the first slide, 
// applies a large dash line format, and saves the result as a PPTX file. 
// This pattern can be used for automating shape styling in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Ellipse, Large Dash, 
// LineDashStyle, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of ellipses with custom dash styles into PPTX files.
// - Build .NET tools for styling shapes in PowerPoint presentations.
// - Generate or modify PPTX content programmatically.
// - Validate shape formatting before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = presentation.Slides[0];

        // Add an ellipse shape
        var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 150);

        // Set line dash style to large dash
        shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.LargeDash;

        // Save the presentation
        var outputPath = "EllipseLongDash.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
