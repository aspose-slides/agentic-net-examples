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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add an empty group shape to the slide
            Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

            // Add three rectangle auto shapes to the group
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 100, 60);
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 50, 100, 60);
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 350, 50, 100, 60);

            // Set alternative text for the group
            groupShape.AlternativeText = "Grouped rectangles";

            // Lock editing of the group (prevent moving, resizing, ungrouping, etc.)
            groupShape.GroupShapeLock.PositionLocked = true;
            groupShape.GroupShapeLock.SizeLocked = true;
            groupShape.GroupShapeLock.UngroupingLocked = true;
            groupShape.GroupShapeLock.GroupingLocked = true;

            // Save the presentation
            pres.Save("GroupedShapes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}