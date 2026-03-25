using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Paths for input and output presentations
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Load existing presentation if it exists, otherwise create a new one
        Aspose.Slides.Presentation pres;
        if (File.Exists(inputPath))
        {
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                pres = new Aspose.Slides.Presentation();
            }
        }
        else
        {
            pres = new Aspose.Slides.Presentation();
        }

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle with solid fill
        Aspose.Slides.IAutoShape solidShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
        solidShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        solidShape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 0, 128, 255); // Blue

        // Add a rectangle with pattern fill
        Aspose.Slides.IAutoShape patternShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 300, 50, 200, 100);
        patternShape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
        patternShape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;
        patternShape.FillFormat.PatternFormat.ForeColor.Color = Color.FromArgb(255, 255, 0, 0); // Red
        patternShape.FillFormat.PatternFormat.BackColor.Color = Color.FromArgb(255, 255, 255, 0); // Yellow

        // Apply outer shadow effect to the solid shape
        solidShape.EffectFormat.EnableOuterShadowEffect();
        solidShape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
        solidShape.EffectFormat.OuterShadowEffect.Direction = 45;
        solidShape.EffectFormat.OuterShadowEffect.Distance = 4.0;
        solidShape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0); // Semi‑transparent black

        // Apply bevel and 3‑D effects to the pattern shape
        patternShape.ThreeDFormat.Depth = 3;
        patternShape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Circle;
        patternShape.ThreeDFormat.BevelTop.Height = 5;
        patternShape.ThreeDFormat.BevelTop.Width = 5;
        patternShape.ThreeDFormat.Camera.CameraType = Aspose.Slides.CameraPresetType.OrthographicFront;
        patternShape.ThreeDFormat.LightRig.LightType = Aspose.Slides.LightRigPresetType.ThreePt;
        patternShape.ThreeDFormat.LightRig.Direction = Aspose.Slides.LightingDirection.Top;

        // Save the modified presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}