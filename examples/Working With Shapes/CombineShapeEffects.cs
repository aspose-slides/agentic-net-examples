using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace CombineShapeEffects
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);

            // Apply 3D depth and bevel effect
            shape.ThreeDFormat.Depth = 5;
            shape.ThreeDFormat.BevelTop.BevelType = Aspose.Slides.BevelPresetType.Circle;
            shape.ThreeDFormat.BevelTop.Height = 5;
            shape.ThreeDFormat.BevelTop.Width = 5;

            // Enable outer shadow effect and configure it
            shape.EffectFormat.EnableOuterShadowEffect();
            shape.EffectFormat.OuterShadowEffect.BlurRadius = 4.0;
            shape.EffectFormat.OuterShadowEffect.Distance = 3.0;
            shape.EffectFormat.OuterShadowEffect.Direction = 45;
            shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0);

            // Save the presentation
            presentation.Save("CombinedEffects.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}