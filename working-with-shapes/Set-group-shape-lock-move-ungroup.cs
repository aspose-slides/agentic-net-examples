using System;
using System.IO;
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

        // Get the first slide and its shape collection
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.IShapeCollection shapes = slide.Shapes;

        // Add a group shape
        Aspose.Slides.IGroupShape group = shapes.AddGroupShape();

        // Add rectangles to the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 50, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 200, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 200, 100, 100);

        // Set the group shape's frame
        group.Frame = new Aspose.Slides.ShapeFrame(100, 100, 300, 300, Aspose.Slides.NullableBool.False, Aspose.Slides.NullableBool.False, 0);

        // Configure lock properties: prevent moving and ungrouping, allow resizing
        group.GroupShapeLock.PositionLocked = true;
        group.GroupShapeLock.UngroupingLocked = true;
        group.GroupShapeLock.SizeLocked = false;

        // Save the presentation
        string outPath = outDir + "GroupShapeLockDemo.pptx";
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}