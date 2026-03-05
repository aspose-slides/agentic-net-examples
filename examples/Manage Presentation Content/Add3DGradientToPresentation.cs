using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a rectangle autoshape
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 200, 150, 250, 250);

        // Set text and font size
        shape.TextFrame.Text = "3D Gradient";
        shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

        // Apply gradient fill
        shape.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
        shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
        shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

        // Configure 3D format
        shape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
        shape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Flat;
        shape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
        shape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Flat;
        shape.ThreeDFormat.ExtrusionHeight = 100;
        shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

        // Save the presentation
        presentation.Save("3DGradient.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}