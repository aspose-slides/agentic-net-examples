using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle shape to the first slide
        Aspose.Slides.IShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

        // Apply 3‑D depth
        shape.ThreeDFormat.Depth = 30;

        // Apply extrusion height
        shape.ThreeDFormat.ExtrusionHeight = 50;

        // Set extrusion color (optional)
        shape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;

        // Save the presentation in PPTX format
        presentation.Save("3DDepthExtrusion.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}