using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle shape that will act as a cube
            Aspose.Slides.IShape cubeShape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 200);

            // Set depth to give 3‑D effect
            cubeShape.ThreeDFormat.Depth = 50;

            // Configure perspective camera
            cubeShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.PerspectiveFront;
            // No rotation needed; keep default orientation
            cubeShape.ThreeDFormat.Camera.SetRotation(0, 0, 0);

            // Set top‑left light source
            cubeShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
            cubeShape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.TopLeft;

            // Save the presentation
            presentation.Save("CubePerspective.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}