using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape rectShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            100,   // X position
            100,   // Y position
            200,   // Width
            100);  // Height

        // Apply 3D depth
        rectShape.ThreeDFormat.Depth = 5;

        // Apply extrusion effect
        rectShape.ThreeDFormat.ExtrusionHeight = 30;
        rectShape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

        // Set camera rotation and type
        rectShape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
        rectShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;

        // Set light rig
        rectShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
        rectShape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

        // Save the presentation
        presentation.Save("3d_shapes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}