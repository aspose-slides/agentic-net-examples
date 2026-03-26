using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape and apply 3D rotation
        Aspose.Slides.IShape rectShape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
        rectShape.ThreeDFormat.Depth = 3;
        rectShape.ThreeDFormat.Camera.SetRotation(30, 40, 50);
        rectShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        rectShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;

        // Add a line shape and apply 3D rotation
        Aspose.Slides.IShape lineShape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 200, 300, 0);
        lineShape.ThreeDFormat.Depth = 2;
        lineShape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
        lineShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        lineShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;

        // Save the presentation
        string outPath = "3d_rotation_output.pptx";
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}