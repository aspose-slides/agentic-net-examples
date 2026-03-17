using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace WordArt3DExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 200, 150, 250, 250);

                // Set the text
                shape.TextFrame.Text = "3D WordArt";

                // Remove shape fill and line
                shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
                shape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

                // Configure text portion fill pattern
                Aspose.Slides.Portion portion = (Aspose.Slides.Portion)shape.TextFrame.Paragraphs[0].Portions[0];
                portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
                portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = System.Drawing.Color.DarkOrange;
                portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = System.Drawing.Color.White;
                portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.LargeGrid;

                // Set font size
                shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

                // Apply WordArt transform
                Aspose.Slides.ITextFrame textFrame = shape.TextFrame;
                textFrame.TextFrameFormat.Transform = Aspose.Slides.TextShapeType.ArchUp;

                // Configure 3D format for the text
                Aspose.Slides.IThreeDFormat threeD = textFrame.TextFrameFormat.ThreeDFormat;
                threeD.ExtrusionHeight = 3.5;
                threeD.Depth = 3;
                threeD.Material = Aspose.Slides.MaterialPresetType.Plastic;
                threeD.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
                threeD.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
                threeD.LightRig.SetRotation(0, 0, 40);
                threeD.Camera.CameraType = Aspose.Slides.CameraPresetType.PerspectiveContrastingRightFacing;

                // Save the presentation
                presentation.Save("WordArt3D.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}