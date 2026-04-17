using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with text
        IAutoShape rect = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
        rect.AddTextFrame("Animated Text");

        // Add a FloatUp effect to the shape
        IEffect effect = slide.Timeline.MainSequence.AddEffect(
            rect,
            EffectType.FloatUp,
            EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

        // Configure acceleration and deceleration for smooth easing
        effect.Timing.Accelerate = 0.3f; // 30% accelerate
        effect.Timing.Decelerate = 0.3f; // 30% decelerate

        // Save the presentation
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "EasingAnimation.pptx");
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other error handling
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}