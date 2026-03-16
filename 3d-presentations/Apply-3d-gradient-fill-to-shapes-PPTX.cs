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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 200, 150, 250, 250);

            shape.TextFrame.Text = "3D Gradient";
            shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

            shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
            shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
            shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);
            shape.FillFormat.GradientFormat.GradientShape = Aspose.Slides.GradientShape.Rectangle;

            shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
            shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
            shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
            shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
            shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Flat;
            shape.ThreeDFormat.ExtrusionHeight = 100;
            shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

            pres.Save("3DGradient.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}