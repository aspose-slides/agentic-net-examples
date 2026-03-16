using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a rectangle shape to the first slide
            IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

            // Set text and font size
            shape.TextFrame.Text = "3D";
            shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

            // Configure 3D format
            shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
            shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
            shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
            shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
            shape.ThreeDFormat.Material = MaterialPresetType.Flat;
            shape.ThreeDFormat.ExtrusionHeight = 100;
            shape.ThreeDFormat.ExtrusionColor.Color = System.Drawing.Color.Blue;

            // Save the presentation
            presentation.Save("3DPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}