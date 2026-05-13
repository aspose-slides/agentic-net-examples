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