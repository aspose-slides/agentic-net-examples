// -----------------------------------------------------------------------------
// Example: Add group shape lock ungroup move edit using C#
//
// Description:
// Demonstrates how to create a group shape containing a rectangle and an ellipse,
// and lock the group to prevent ungrouping, moving, resizing, selecting, and rotating
// using Aspose.Slides for .NET. The example creates a new presentation, adds the
// locked group shape to the first slide, and saves the result as a PPTX file.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, GroupShape, ShapeLock, UngroupingLocked,
// PositionLocked, SizeLocked, SelectLocked, RotationLocked, Presentation Processing
//
// Use Cases:
// - Generate PowerPoint files with locked group shapes to protect layout.
// - Automate creation of read‑only slide elements in .NET applications.
// - Ensure presentation content cannot be altered unintentionally.
// - Build tools for preparing secure PPTX templates.
// -----------------------------------------------------------------------------

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
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a group shape to the slide
        IGroupShape group = slide.Shapes.AddGroupShape();

        // Add shapes inside the group
        group.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 50);
        group.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 50);

        // Lock the group shape to prevent ungrouping, moving, resizing, selecting, and rotating
        group.GroupShapeLock.UngroupingLocked = true;
        group.GroupShapeLock.PositionLocked = true;
        group.GroupShapeLock.SizeLocked = true;
        group.GroupShapeLock.SelectLocked = true;
        group.GroupShapeLock.RotationLocked = true;

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}
