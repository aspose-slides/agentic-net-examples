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