// -----------------------------------------------------------------------------
// Example: Add group shape rectangle fill orange lock using C#
//
// Description:
// Demonstrates how to add a group shape containing a rectangle with a solid orange
// fill and lock the group to prevent further modifications using C# and Aspose.Slides
// for .NET. The example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, enforce shape grouping
// constraints, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Group, Shape, Rectangle, Fill, Lock,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a grouped rectangle with orange fill and lock the group.
// - Build C# tools for PowerPoint presentation processing with shape constraints.
// - Generate or transform PPTX files in .NET applications while preserving group integrity.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a group shape to the slide
        IGroupShape groupShape = slide.Shapes.AddGroupShape();

        // Add a rectangle inside the group shape
        IAutoShape rectangle = (IAutoShape)groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

        // Set fill to solid orange
        rectangle.FillFormat.FillType = FillType.Solid;
        rectangle.FillFormat.SolidFillColor.Color = Color.Orange;

        // Lock the group shape to prevent adding/removing shapes
        groupShape.GroupShapeLock.GroupingLocked = true;

        // Save the presentation
        presentation.Save("GroupShapeWithOrangeRectangle.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}
