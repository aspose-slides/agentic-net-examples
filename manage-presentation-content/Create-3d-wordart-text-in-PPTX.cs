using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 500, 200);

            // Set the text for WordArt
            autoShape.TextFrame.Text = "3D WordArt";

            // Apply a WordArt transform effect
            autoShape.TextFrame.TextFrameFormat.Transform = Aspose.Slides.TextShapeType.ArchUp;

            // Configure 3D format for the text
            Aspose.Slides.IThreeDFormat threeD = autoShape.TextFrame.TextFrameFormat.ThreeDFormat;
            threeD.ExtrusionHeight = 5;
            threeD.Depth = 3;
            threeD.Material = Aspose.Slides.MaterialPresetType.Plastic;
            threeD.LightRig.LightType = Aspose.Slides.LightRigPresetType.Balanced;
            threeD.LightRig.Direction = Aspose.Slides.LightingDirection.Top;
            threeD.LightRig.SetRotation(0, 0, 40);
            threeD.Camera.CameraType = Aspose.Slides.CameraPresetType.PerspectiveContrastingRightFacing;

            // Enable outer shadow effect and set its properties
            autoShape.EffectFormat.EnableOuterShadowEffect();
            autoShape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
            autoShape.EffectFormat.OuterShadowEffect.Distance = 3.0;
            autoShape.EffectFormat.OuterShadowEffect.Direction = 45.0f;
            autoShape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Gray;

            // Save the presentation
            presentation.Save("3DWordArt.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}