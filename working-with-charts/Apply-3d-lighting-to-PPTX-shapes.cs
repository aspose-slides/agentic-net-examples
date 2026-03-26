using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle shape with 3D rotation and lighting effects
            Aspose.Slides.IShape rectShape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 200);
            rectShape.ThreeDFormat.Depth = 3;
            rectShape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
            rectShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
            rectShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
            rectShape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

            // Add a line shape with 3D rotation and lighting effects
            Aspose.Slides.IShape lineShape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 350, 100, 200, 0);
            lineShape.ThreeDFormat.Depth = 3;
            lineShape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
            lineShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
            lineShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
            lineShape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

            // Save the presentation
            presentation.Save("3d_lighting.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}