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
        IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 150);

        // Set fill color
        rectangle.FillFormat.FillType = FillType.Solid;
        rectangle.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 255, 255, 200); // Light yellow

        // Enable and configure outer shadow effect
        rectangle.EffectFormat.EnableOuterShadowEffect();
        rectangle.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
        rectangle.EffectFormat.OuterShadowEffect.Direction = 45;
        rectangle.EffectFormat.OuterShadowEffect.Distance = 4.0;
        rectangle.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0); // Semi‑transparent black

        // Enable and configure glow effect
        rectangle.EffectFormat.EnableGlowEffect();
        rectangle.EffectFormat.GlowEffect.Radius = 8.0;
        rectangle.EffectFormat.GlowEffect.Color.Color = Color.FromArgb(255, 255, 215, 0); // Gold

        // Save the presentation
        string outputPath = "OuterShadowGlow.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}