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
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a group shape to the slide
            IGroupShape groupShape = slide.Shapes.AddGroupShape();

            // Add three auto shapes to the group
            groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 60);
            groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 50, 100, 60);
            groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 350, 50, 100, 60);

            // Set alternative text for the group
            groupShape.AlternativeText = "Group of three rectangles";

            // Lock editing of the group shape
            groupShape.GroupShapeLock.PositionLocked = true;
            groupShape.GroupShapeLock.SizeLocked = true;
            groupShape.GroupShapeLock.RotationLocked = true;
            groupShape.GroupShapeLock.SelectLocked = true;
            groupShape.GroupShapeLock.UngroupingLocked = true;
            groupShape.GroupShapeLock.GroupingLocked = true;

            // Save the presentation
            try
            {
                presentation.Save("GroupedShapes.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions such as unsupported format
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}