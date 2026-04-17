using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var pres = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = pres.Slides[0];

        // Add a group shape to the slide
        var groupShape = slide.Shapes.AddGroupShape();

        // Lock the group shape to prevent adding new shapes
        groupShape.GroupShapeLock.GroupingLocked = true;

        // Attempt to add a new shape to the locked group and catch the exception
        try
        {
            groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
        }
        catch (Exception ex)
        {
            // Output the exception message
            Console.WriteLine("Exception caught: " + ex.Message);
        }

        // Save the presentation
        var outPath = "GroupShapeLocked_out.pptx";
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}