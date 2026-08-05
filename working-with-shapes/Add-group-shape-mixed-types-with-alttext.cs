// -----------------------------------------------------------------------------
// Example: Add group shape mixed types with alttext using C#
//
// Description:
// Demonstrates how to add a group shape containing mixed shape types (rectangle,
// ellipse, triangle, line) and assign alternative text to the group using C# and
// Aspose.Slides for .NET. The example creates a new presentation, adds the group
// shape to the first slide, populates it with various shapes, sets the group's
// AlternativeText property, and saves the file as a PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Group, Shape, Mixed, Types,
// Alternative Text, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding grouped shapes with mixed types and alt text.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with grouped content in .NET applications.
// - Ensure accessibility by providing alternative text for grouped shapes.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an empty group shape to the slide
        Aspose.Slides.IGroupShape group = slide.Shapes.AddGroupShape();

        // Populate the group with different types of shapes
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 100, 50);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 200, 50, 80, 80);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Triangle, 300, 50, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 200, 150);

        // Assign a collective alternative text description to the group shape
        ((Aspose.Slides.Shape)group).AlternativeText = "A group containing various shapes";

        // Save the presentation
        pres.Save("GroupShapeExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
