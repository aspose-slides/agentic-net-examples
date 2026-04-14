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

        // Add a rectangle shape to the slide
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);

        // Set a solid fill for the shape (optional)
        shape.FillFormat.FillType = FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.LightGray;

        // Enable outer shadow effect
        shape.EffectFormat.EnableOuterShadowEffect();

        // Configure the outer shadow: 4 point blur radius, 45 degree direction, semi‑transparent black color
        shape.EffectFormat.OuterShadowEffect.BlurRadius = 4.0;
        shape.EffectFormat.OuterShadowEffect.Direction = 45.0f;
        shape.EffectFormat.OuterShadowEffect.Distance = 5.0; // example distance
        shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0); // 50% transparent black

        // Save the presentation
        presentation.Save("OuterShadowExample.pptx", SaveFormat.Pptx);
    }
}