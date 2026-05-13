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
        {
            Directory.CreateDirectory(outDir);
        }
        string outputPath = outDir + "LockedGroupShape.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a group shape to the slide
        Aspose.Slides.IGroupShape group = slide.Shapes.AddGroupShape();

        // Add shapes inside the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 100, 50);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 200, 50, 100, 50);

        // Lock the group shape to prevent ungrouping, moving, resizing, selecting, and rotating
        group.GroupShapeLock.UngroupingLocked = true;
        group.GroupShapeLock.PositionLocked = true;
        group.GroupShapeLock.SizeLocked = true;
        group.GroupShapeLock.SelectLocked = true;
        group.GroupShapeLock.RotationLocked = true;

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}