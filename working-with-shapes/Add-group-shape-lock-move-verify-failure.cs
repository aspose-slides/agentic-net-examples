using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            var slide = pres.Slides[0];

            // Add an empty group shape
            var groupShape = slide.Shapes.AddGroupShape();

            // Set initial position
            groupShape.X = 100;
            groupShape.Y = 100;

            // Lock moving of the group shape
            groupShape.GroupShapeLock.PositionLocked = true;

            // Store original position
            float originalX = groupShape.X;
            float originalY = groupShape.Y;

            // Attempt to move the group shape
            try
            {
                groupShape.X += 50;
                groupShape.Y += 50;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception while moving: " + ex.Message);
            }

            // Verify if position changed
            bool moved = (groupShape.X != originalX) || (groupShape.Y != originalY);
            Console.WriteLine(moved ? "Move succeeded (lock not enforced)." : "Move failed as expected due to lock.");

            // Save the presentation
            try
            {
                pres.Save("GroupShapeLockDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
                // Format not supported.
            }
        }
    }
}