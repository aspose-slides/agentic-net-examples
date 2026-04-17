using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GroupShapesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a group shape to the slide
            IGroupShape groupShape = slide.Shapes.AddGroupShape();

            // Add three auto shapes inside the group
            groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 60);
            groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 60);
            groupShape.Shapes.AddAutoShape(ShapeType.Triangle, 350, 50, 100, 60);

            // Set alternative text for the group
            groupShape.AlternativeText = "Three grouped shapes";

            // Lock editing of the group shape
            groupShape.GroupShapeLock.PositionLocked = true;
            groupShape.GroupShapeLock.SizeLocked = true;
            groupShape.GroupShapeLock.RotationLocked = true;
            groupShape.GroupShapeLock.SelectLocked = true;
            groupShape.GroupShapeLock.UngroupingLocked = true;
            groupShape.GroupShapeLock.GroupingLocked = true;

            // Save the presentation
            pres.Save("GroupedShapes.pptx", SaveFormat.Pptx);
        }
    }
}