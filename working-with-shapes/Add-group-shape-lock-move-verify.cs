using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a group shape to the slide
                IGroupShape groupShape = slide.Shapes.AddGroupShape();

                // Add some shapes inside the group for visual reference
                groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100f, 100f, 100f, 100f);
                groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 250f, 100f, 100f, 100f);

                // Lock the group shape to prevent moving
                groupShape.GroupShapeLock.PositionLocked = true;

                // Attempt to move the group shape
                try
                {
                    // Store original position
                    float originalX = groupShape.X;
                    float originalY = groupShape.Y;

                    // Attempt to change position
                    groupShape.X = originalX + 50f;
                    groupShape.Y = originalY + 50f;

                    // Verify if the position has changed
                    if (groupShape.X == originalX && groupShape.Y == originalY)
                    {
                        Console.WriteLine("Move operation was blocked by PositionLocked.");
                    }
                    else
                    {
                        Console.WriteLine("Move operation succeeded unexpectedly.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exception that occurs during move attempt
                    Console.WriteLine("Exception occurred while moving the group shape: " + ex.Message);
                }

                // Save the presentation
                pres.Save("GroupShapeLockExample.pptx", SaveFormat.Pptx);
            }
        }
    }
}