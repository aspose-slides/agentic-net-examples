using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output directory
        string outDir = "Output" + Path.DirectorySeparatorChar;
        if (!Directory.Exists(outDir))
            Directory.CreateDirectory(outDir);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Get the shape collection of the slide
        Aspose.Slides.IShapeCollection shapes = slide.Shapes;

        // Add a group shape
        Aspose.Slides.IGroupShape groupShape = shapes.AddGroupShape();

        // Add some rectangles inside the group shape
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

        // Set the group shape frame
        groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

        // Lock the group shape to prevent ungrouping, moving, and editing
        groupShape.GroupShapeLock.UngroupingLocked = true;
        groupShape.GroupShapeLock.PositionLocked = true;
        groupShape.GroupShapeLock.SelectLocked = true;
        groupShape.GroupShapeLock.SizeLocked = true;

        // Save the presentation
        try
        {
            pres.Save(outDir + "LockedGroupShape.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        pres.Dispose();
    }
}