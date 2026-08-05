// -----------------------------------------------------------------------------
// Example: Apply solid fill and pattern overlay using C#
//
// Description:
// Demonstrates how to apply a solid fill to a rectangle shape and then overlay
// a pattern fill with semi-transparency using C# and Aspose.Slides for .NET.
// The example creates a presentation, adds two overlapping rectangle shapes—one
// with a solid blue fill and another with a diagonal cross pattern—then saves
// the result as a PPTX file. This pattern can be used to automate visual styling
// of shapes in PowerPoint presentations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Solid, Fill, Pattern, Shape,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying solid fill and pattern overlay to shapes.
// - Build C# tools for advanced shape styling in PowerPoint presentations.
// - Generate or transform PPTX files with custom visual effects in .NET applications.
// - Validate presentation workflows involving layered shape fills before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with solid fill
        Aspose.Slides.IShape solidShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);
        solidShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        solidShape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 0, 120, 215); // solid blue

        // Add another rectangle on top with pattern fill and semi-transparency
        Aspose.Slides.IShape patternShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);
        patternShape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
        patternShape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;
        // Semi-transparent background color
        patternShape.FillFormat.PatternFormat.BackColor.Color = Color.FromArgb(128, 255, 255, 255);
        // Semi-transparent foreground color
        patternShape.FillFormat.PatternFormat.ForeColor.Color = Color.FromArgb(128, 0, 0, 0);

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose presentation
        presentation.Dispose();
    }
}
