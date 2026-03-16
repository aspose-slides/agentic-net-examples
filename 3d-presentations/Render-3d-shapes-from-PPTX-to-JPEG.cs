using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation())
            {
                IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
                shape.TextFrame.Text = "3D Shape";
                shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 48;

                // Apply 3D effects
                shape.ThreeDFormat.Depth = 5;
                shape.ThreeDFormat.ExtrusionHeight = 100;
                shape.ThreeDFormat.Material = MaterialPresetType.Plastic;
                shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
                shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
                shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
                shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
                shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

                // Export slide as JPEG
                IImage image = pres.Slides[0].GetImage(2f, 2f);
                image.Save("slide_3d.jpg", Aspose.Slides.ImageFormat.Jpeg);
                image.Dispose();

                // Save the presentation
                pres.Save("presentation_3d.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}