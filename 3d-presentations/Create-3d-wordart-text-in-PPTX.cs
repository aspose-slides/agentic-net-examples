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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 200, 150, 250, 250);
                shape.TextFrame.Text = "3D WordArt";
                shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                Aspose.Slides.Portion portion = (Aspose.Slides.Portion)shape.TextFrame.Paragraphs[0].Portions[0];
                portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
                portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
                portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
                portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.LargeGrid;

                shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

                Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
                textFrame.TextFrameFormat.Transform = Aspose.Slides.TextShapeType.ArchUp;

                // Apply 3D WordArt effects
                textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5;
                textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;
                textFrame.TextFrameFormat.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;
                textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
                textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
                textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
                textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.PerspectiveContrastingRightFacing;

                // Save the presentation
                presentation.Save("WordArt3D.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}