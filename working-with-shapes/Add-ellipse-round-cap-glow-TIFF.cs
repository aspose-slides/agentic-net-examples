using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Add an ellipse shape
            var ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 200);

            // Set line cap to round
            ellipse.LineFormat.CapStyle = Aspose.Slides.LineCapStyle.Round;

            // Enable glow effect
            ellipse.EffectFormat.EnableGlowEffect();

            // Set glow radius
            ellipse.EffectFormat.GlowEffect.Radius = 10;

            // Set glow color
            ellipse.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Yellow;

            // Save the presentation as TIFF
            var outputPath = "output.tiff";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported: ex.Message
        }
    }
}