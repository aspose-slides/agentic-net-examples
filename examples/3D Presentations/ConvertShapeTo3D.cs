using System;

public class Program
{
    public static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape (2D)
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Set some text for the shape
        shape.TextFrame.Text = "3D Shape";

        // Convert the shape to 3D by setting depth and extrusion height
        shape.ThreeDFormat.Depth = 50;               // Depth of the 3D shape
        shape.ThreeDFormat.ExtrusionHeight = 30;     // Extrusion height

        // Optional: configure material and lighting for better 3D effect
        shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;
        shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
        shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

        // Save the presentation before exiting
        presentation.Save("Converted3DShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}