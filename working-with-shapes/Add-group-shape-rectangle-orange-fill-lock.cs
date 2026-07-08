using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

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

        // Add a rectangle (auto shape) inside the group
        IAutoShape rectangle = (IAutoShape)groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

        // Set fill to solid orange color
        rectangle.FillFormat.FillType = FillType.Solid;
        rectangle.FillFormat.SolidFillColor.Color = Color.Orange;

        // Lock the rectangle (prevent moving, resizing, grouping)
        rectangle.ShapeLock.PositionLocked = true;
        rectangle.ShapeLock.SizeLocked = true;
        rectangle.ShapeLock.GroupingLocked = true;

        // Optionally lock the group shape as well
        groupShape.GroupShapeLock.PositionLocked = true;
        groupShape.GroupShapeLock.SizeLocked = true;
        groupShape.GroupShapeLock.GroupingLocked = true;

        // Save the presentation
        presentation.Save("GroupShapeExample.pptx", SaveFormat.Pptx);
    }
}