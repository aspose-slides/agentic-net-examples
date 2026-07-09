using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add an ellipse shape
        IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 200);

        // Set line cap to round
        ellipse.LineFormat.CapStyle = LineCapStyle.Round;

        // Enable glow effect
        ellipse.EffectFormat.EnableGlowEffect();

        // Set glow radius if the effect is available
        if (ellipse.EffectFormat.GlowEffect != null)
        {
            ellipse.EffectFormat.GlowEffect.Radius = 10.0;
        }

        // Save the presentation as TIFF
        string outputPath = "output.tiff";
        try
        {
            TiffOptions options = new TiffOptions();
            presentation.Save(outputPath, SaveFormat.Tiff, options);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}