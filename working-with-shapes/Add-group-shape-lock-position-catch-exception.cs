using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output directory and file
        string outDir = "Output" + Path.DirectorySeparatorChar;
        if (!Directory.Exists(outDir))
            Directory.CreateDirectory(outDir);
        string outPath = outDir + "GroupShapeLockDemo.pptx";

        // Create a new presentation
        Presentation pres = new Presentation();
        // Get the first slide
        ISlide slide = pres.Slides[0];
        // Add a group shape
        IGroupShape group = slide.Shapes.AddGroupShape();
        // Add shapes inside the group
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);
        // Set the group shape frame
        group.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);
        // Lock the position of the group shape
        group.GroupShapeLock.PositionLocked = true;
        // Attempt to move the locked group shape and capture the exception
        try
        {
            // This operation should fail because the position is locked
            group.Frame = new ShapeFrame(200, 400, 500, 40, NullableBool.False, NullableBool.False, 0);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception caught while moving locked group shape: " + ex.Message);
        }

        // Save the presentation
        pres.Save(outPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}