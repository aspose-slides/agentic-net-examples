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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 200);

        // Set the text for the shape
        autoShape.TextFrame.Text = "3D WordArt";

        // Remove fill and line so only the text is visible
        autoShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        autoShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.NoFill;

        // Configure portion formatting (optional)
        Aspose.Slides.Portion portion = (Aspose.Slides.Portion)autoShape.TextFrame.Paragraphs[0].Portions[0];
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkOrange;

        // Set font size
        autoShape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 120;

        // Apply WordArt transform effect
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
        textFrame.TextFrameFormat.Transform = Aspose.Slides.TextShapeType.ArchUp;

        // Configure 3D format for the text
        textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 5;
        textFrame.TextFrameFormat.ThreeDFormat.Depth = 4;
        textFrame.TextFrameFormat.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;
        textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
        textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
        textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 45);
        textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.PerspectiveContrastingRightFacing;

        // Save the presentation
        presentation.Save("WordArt3D.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}