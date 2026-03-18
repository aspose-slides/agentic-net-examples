using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape with some text
                IAutoShape shape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
                shape.TextFrame.Text = "Animated Shape";

                // Access the animation timeline
                Aspose.Slides.IAnimationTimeLine timeline = slide.Timeline;

                // Add a Fade effect to the shape
                IEffect effect = timeline.MainSequence.AddEffect(
                    shape,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Set the duration of the effect to 2 seconds
                effect.Timing.Duration = 2.0F;

                // Save the presentation
                presentation.Save("Animated.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}