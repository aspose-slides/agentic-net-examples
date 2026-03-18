using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);
            shape.TextFrame.Text = "3D Rotated Shape";
            // Apply 3D rotation: X=30°, Y=40°, Z=50°
            shape.ThreeDFormat.Camera.SetRotation(30, 40, 50);
            // Rotate around Z-axis directly
            shape.Rotation = 50f;
            // Save the presentation
            presentation.Save("Shape3DRotation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}