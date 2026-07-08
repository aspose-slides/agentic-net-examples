using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add an ellipse shape to the slide
                IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 200, 100);

                // Apply a fade‑in animation that starts on click
                IEffect effect = slide.Timeline.MainSequence.AddEffect(
                    ellipse,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.OnClick);

                // Save the presentation
                presentation.Save("EllipseAnimation.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported file format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}