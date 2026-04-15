using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output directory and file
        var outDir = "Output" + Path.DirectorySeparatorChar;
        if (!Directory.Exists(outDir))
            Directory.CreateDirectory(outDir);
        var outputPath = outDir + "GroupShapeLockDemo.pptx";

        // Create a new presentation
        var pres = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = pres.Slides[0];

        // Add a group shape to the slide
        var group = slide.Shapes.AddGroupShape();

        // Add some rectangles to the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 50, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 200, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 200, 100, 100);

        // Set lock properties: prevent moving and ungrouping, allow resizing
        group.GroupShapeLock.PositionLocked = true;
        group.GroupShapeLock.UngroupingLocked = true;
        group.GroupShapeLock.SizeLocked = false; // allow resizing

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}