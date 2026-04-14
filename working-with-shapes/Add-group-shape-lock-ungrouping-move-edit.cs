using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddGroupShapeLockUngroupingMoveEdit
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add an empty group shape to the slide
                Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

                // Add some shapes inside the group (example rectangles)
                groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
                groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 350, 100, 200, 100);

                // Lock the group shape to prevent ungrouping, moving, and editing
                groupShape.GroupShapeLock.UngroupingLocked = true;   // Prevent ungrouping
                groupShape.GroupShapeLock.PositionLocked = true;    // Prevent moving
                groupShape.GroupShapeLock.SizeLocked = true;        // Prevent resizing
                groupShape.GroupShapeLock.SelectLocked = true;      // Prevent selection/editing

                // Save the presentation
                presentation.Save("LockedGroupShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}