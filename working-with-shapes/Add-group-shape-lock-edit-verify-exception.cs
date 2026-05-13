using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();
        // Get the first slide
        ISlide slide = pres.Slides[0];
        // Add a group shape to the slide
        IGroupShape groupShape = slide.Shapes.AddGroupShape();
        // Lock the group shape to prevent adding new shapes
        groupShape.GroupShapeLock.GroupingLocked = true;
        try
        {
            // Attempt to add a rectangle to the locked group shape
            groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
        }
        catch (Exception ex)
        {
            // Handle the exception when adding is forbidden
            Console.WriteLine("Exception caught: " + ex.Message);
        }
        // Save the presentation
        string outputPath = "GroupShapeLockExample.pptx";
        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}