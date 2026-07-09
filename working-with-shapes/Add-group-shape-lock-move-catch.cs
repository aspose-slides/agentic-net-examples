using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a group shape to the slide
            Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

            // Lock the position of the group shape
            groupShape.GroupShapeLock.PositionLocked = true;

            // Attempt to move the locked group shape and capture any exception
            try
            {
                // This should raise an exception because the position is locked
                groupShape.X = 100f;
                groupShape.Y = 100f;
                Console.WriteLine("Group shape moved successfully (unexpected).");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught while moving locked group shape: " + ex.Message);
            }

            // Save the presentation before exiting
            string outputPath = "GroupShapeLocked.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}