using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape that will act as a cube
        Aspose.Slides.IAutoShape cubeShape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 200);

        // Set optional text for the shape
        cubeShape.TextFrame.Text = "Cube";

        // Configure 3‑D format: use a perspective camera
        cubeShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.PerspectiveFront;

        // Set light rig to top‑left direction
        cubeShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
        cubeShape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.TopLeft;

        // Define depth to give the shape a 3‑D appearance
        cubeShape.ThreeDFormat.Depth = 100;

        // Save the presentation
        try
        {
            presentation.Save("Cube3D.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        finally
        {
            // Release resources
            presentation.Dispose();
        }
    }
}