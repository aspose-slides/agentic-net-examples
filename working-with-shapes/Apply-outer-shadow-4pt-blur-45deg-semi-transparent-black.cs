using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);
        // Set solid fill color (white)
        shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        shape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 255, 255, 255);
        // Enable outer shadow effect
        shape.EffectFormat.EnableOuterShadowEffect();
        // Configure outer shadow: blur radius 4, direction 45°, distance 5, semi‑transparent black
        shape.EffectFormat.OuterShadowEffect.BlurRadius = 4.0;
        shape.EffectFormat.OuterShadowEffect.Direction = 45.0f;
        shape.EffectFormat.OuterShadowEffect.Distance = 5.0;
        shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0);
        // Save the presentation
        try
        {
            presentation.Save("OuterShadowExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle unsupported format or other errors
        }
    }
}