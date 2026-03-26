using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IShape rectangleShape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

        // Apply 3D depth
        rectangleShape.ThreeDFormat.Depth = 5;

        // Configure camera type and rotation
        rectangleShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        rectangleShape.ThreeDFormat.Camera.SetRotation(20, 30, 40);

        // Set light rig type and direction for lighting effect
        rectangleShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
        rectangleShape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

        // Save the presentation
        presentation.Save("3DLightingEffects.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}