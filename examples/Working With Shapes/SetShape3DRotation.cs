using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add a rectangle auto shape to the first slide
        Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 200);

        // Set rotation around the Z‑axis (2‑D rotation)
        shape.Rotation = 30f; // 30 degrees clockwise

        // Set 3‑D rotation (X, Y, Z axes) using the shape's camera
        shape.ThreeDFormat.Camera.SetRotation(20, 30, 40); // X=20°, Y=30°, Z=40°

        // Save the presentation before exiting
        pres.Save("Shape3DRotation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}