using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape with solid fill and a solid border
        Aspose.Slides.IAutoShape solidShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
        solidShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        solidShape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 100, 150, 200);
        solidShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        solidShape.LineFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 0, 0, 0);
        solidShape.LineFormat.Width = 2;

        // Apply outer shadow effect to the solid shape
        solidShape.EffectFormat.EnableOuterShadowEffect();
        solidShape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
        solidShape.EffectFormat.OuterShadowEffect.Direction = 45;
        solidShape.EffectFormat.OuterShadowEffect.Distance = 4.0;
        solidShape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0);

        // Add a rectangle shape with pattern fill
        Aspose.Slides.IAutoShape patternShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 50, 200, 100);
        patternShape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
        patternShape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;
        patternShape.FillFormat.PatternFormat.ForeColor.Color = Color.FromArgb(255, 255, 0, 0);
        patternShape.FillFormat.PatternFormat.BackColor.Color = Color.FromArgb(255, 255, 255, 0);
        patternShape.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        patternShape.LineFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 0, 0, 0);
        patternShape.LineFormat.Width = 1.5;

        // Apply bevel effect to the pattern shape
        patternShape.ThreeDFormat.Depth = 3;
        patternShape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Circle;
        patternShape.ThreeDFormat.BevelTop.Height = 5;
        patternShape.ThreeDFormat.BevelTop.Width = 5;
        patternShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        patternShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.ThreePt;
        patternShape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
        patternShape.ThreeDFormat.Material = Aspose.Slides.MaterialPresetType.Plastic;

        // Add a rectangle shape with text and apply inner shadow to the text
        Aspose.Slides.IAutoShape textShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 200, 450, 150);
        textShape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        textShape.AddTextFrame("Custom Styled Text");
        Aspose.Slides.IPortion textPortion = textShape.TextFrame.Paragraphs[0].Portions[0];
        Aspose.Slides.IPortionFormat portionFormat = textPortion.PortionFormat;
        portionFormat.FontHeight = 32;
        portionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        portionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        portionFormat.EffectFormat.EnableInnerShadowEffect();
        portionFormat.EffectFormat.InnerShadowEffect.BlurRadius = 4.0;
        portionFormat.EffectFormat.InnerShadowEffect.Direction = 135;
        portionFormat.EffectFormat.InnerShadowEffect.Distance = 3.0;
        portionFormat.EffectFormat.InnerShadowEffect.ShadowColor.Color = Color.FromArgb(100, 0, 0, 0);
        portionFormat.EffectFormat.InnerShadowEffect.ShadowColor.ColorType = Aspose.Slides.ColorType.Scheme;
        portionFormat.EffectFormat.InnerShadowEffect.ShadowColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;

        // Save the presentation
        string outputPath = "CustomStyledPresentation.pptx";
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}