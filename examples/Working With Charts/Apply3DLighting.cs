using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape rectShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            100,   // X position
            100,   // Y position
            300,   // Width
            200);  // Height

        // Set 3D depth of the shape
        rectShape.ThreeDFormat.Depth = 5;

        // Configure the camera for the shape
        rectShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;

        // Apply a light rig and set its direction
        rectShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.ThreePt;
        rectShape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

        // Save the presentation
        presentation.Save("Apply3DLighting.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}