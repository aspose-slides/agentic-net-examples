using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Output file path
        string outPath = "RotateShape3D_out.pptx";
        string outDir = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(outPath));
        if (!System.IO.Directory.Exists(outDir))
            System.IO.Directory.CreateDirectory(outDir);

        // Index of the slide to work on
        int slideIndex = 0;

        // Add a rectangle shape and apply 3‑D rotation
        Aspose.Slides.IShape rectShape = presentation.Slides[slideIndex].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,   // shape type
            100,                                 // X position
            100,                                 // Y position
            200,                                 // width
            100);                                // height
        rectShape.ThreeDFormat.Depth = 5;                                   // depth of the shape
        rectShape.ThreeDFormat.Camera.SetRotation(30, 20, 10);              // rotation X, Y, Z
        rectShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        rectShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;

        // Add a line shape and apply 3‑D rotation
        Aspose.Slides.IShape lineShape = presentation.Slides[slideIndex].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Line,       // shape type
            350,                                 // X position
            150,                                 // Y position
            200,                                 // width (length of the line)
            0);                                  // height (line thickness is set via line format, not needed here)
        lineShape.ThreeDFormat.Depth = 3;
        lineShape.ThreeDFormat.Camera.SetRotation(0, 45, 0);
        lineShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        lineShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;

        // Save the presentation
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}