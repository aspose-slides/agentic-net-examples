using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with text
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);
        shape.AddTextFrame("Animated Text");

        // Add an animation effect to the shape
        Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
            shape,
            Aspose.Slides.Animation.EffectType.Appear,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Set start delay (in seconds) for the animation
        effect.Timing.TriggerDelayTime = 2.0f; // 2 seconds delay

        // Save the presentation
        presentation.Save("SetAnimationStartDelay_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}