using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation presentation = new Presentation())
        {
            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a group shape to the slide
            IGroupShape groupShape = slide.Shapes.AddGroupShape();

            // Add a rectangle inside the group for demonstration
            groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

            // Lock the group shape's position to prevent moving
            groupShape.GroupShapeLock.PositionLocked = true;

            // Attempt to move the group shape
            try
            {
                // Store original position
                float originalX = groupShape.X;
                float originalY = groupShape.Y;

                // Try to change position
                groupShape.X = originalX + 50;
                groupShape.Y = originalY + 50;

                // Verify if move was blocked
                if (groupShape.X == originalX && groupShape.Y == originalY)
                {
                    Console.WriteLine("Move operation was blocked by PositionLocked.");
                }
                else
                {
                    Console.WriteLine("Move operation succeeded despite lock.");
                }
            }
            catch (Exception ex)
            {
                // Expected exception if moving is not allowed
                Console.WriteLine("Exception while moving group shape: " + ex.Message);
            }

            // Save the presentation
            presentation.Save("GroupShapeLockDemo.pptx", SaveFormat.Pptx);
        }
    }
}