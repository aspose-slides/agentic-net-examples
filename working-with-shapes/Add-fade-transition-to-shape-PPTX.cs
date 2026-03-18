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
            Presentation presentation = new Presentation();

            // Add a rectangle shape to the first slide
            IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
            shape.TextFrame.Text = "Fade Effect";

            // Add a Fade animation effect to the shape
            IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
                shape,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Configure timing: set duration to 2 seconds (2000 milliseconds)
            effect.Timing.Duration = 2000;

            // Save the presentation
            presentation.Save("FadeEffect.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}