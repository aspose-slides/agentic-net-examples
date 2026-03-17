using System;
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
                // Add a rectangle shape to the first slide
                IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(
                    ShapeType.Rectangle, 100, 100, 200, 100);
                shape.TextFrame.Text = "Animated Shape";

                // Add a Fade entrance effect to the shape
                IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
                    shape,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Set effect timing: duration of 2 seconds (float literal)
                effect.Timing.Duration = 2.0F;

                // Make the effect repeat until the end of the slide
                effect.Timing.RepeatUntilEndSlide = true;

                // Save the presentation
                presentation.Save("AnimatedShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}