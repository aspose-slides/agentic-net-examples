// -----------------------------------------------------------------------------
// Example: Configure three d perspective camera top left using C#
//
// Description:
// Demonstrates how to configure a three‑dimensional perspective camera with a
// top‑left light source for a shape using C# and Aspose.Slides for .NET. The
// example creates a rectangle shape, applies 3D depth, sets a perspective
// camera, positions the light rig to the top‑left, and saves the presentation.
// This pattern can be used to automate 3D visual enhancements in PowerPoint
// files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Three‑Dimensional,
// Perspective Camera, Top‑Left Light, 3D Shape, Presentation Processing
//
// Use Cases:
// - Automate adding 3D perspective camera with top‑left lighting to shapes.
// - Build C# tools for enhancing PowerPoint presentations with 3D effects.
// - Generate or transform PPTX files with custom camera and lighting settings.
// - Validate 3D presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var cubeShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 200);
            // Configure 3D depth to give a cube appearance
            cubeShape.ThreeDFormat.Depth = 100;
            // Use a perspective camera
            cubeShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.PerspectiveFront;
            // Set top‑left light source
            cubeShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
            cubeShape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.TopLeft;
            // Save the presentation
            presentation.Save("Cube3D.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, file I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
