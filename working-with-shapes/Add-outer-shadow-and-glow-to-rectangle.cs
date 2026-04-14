using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();
        // Get the first slide
        ISlide slide = presentation.Slides[0];
        // Add a rectangle shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 150);
        // Set fill color
        shape.FillFormat.FillType = FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 200, 200, 255);
        // Enable outer shadow effect
        shape.EffectFormat.EnableOuterShadowEffect();
        shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
        shape.EffectFormat.OuterShadowEffect.Direction = 45.0f;
        shape.EffectFormat.OuterShadowEffect.Distance = 4.0;
        shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0);
        // Enable glow effect
        shape.EffectFormat.EnableGlowEffect();
        shape.EffectFormat.GlowEffect.Radius = 10.0;
        shape.EffectFormat.GlowEffect.Color.Color = Color.FromArgb(255, 255, 255, 0);
        // Save the presentation
        presentation.Save("HighlightedRectangle.pptx", SaveFormat.Pptx);
    }
}