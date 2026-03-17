using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);

            shape.TextFrame.Text = "3D Shape";

            // Apply 3D depth and extrusion effects
            shape.ThreeDFormat.Depth = 30;
            shape.ThreeDFormat.ExtrusionHeight = 100;
            shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;
            shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;

            // Save the presentation before exiting
            presentation.Save("3DShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}