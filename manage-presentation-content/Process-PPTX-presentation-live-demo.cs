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
            // Create a new presentation
            using (var pres = new Presentation())
            {
                // Access the first slide
                var slide = pres.Slides[0];

                // Add a rectangle shape with some text
                var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
                shape.TextFrame.Text = "Hello Aspose.Slides";

                // Apply a fade transition with a 3‑second advance time
                slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                slide.SlideShowTransition.AdvanceOnClick = true;
                slide.SlideShowTransition.AdvanceAfterTime = 3000;

                // Add a Fly entrance effect to the shape
                var effect = slide.Timeline.MainSequence.AddEffect(
                    shape,
                    Aspose.Slides.Animation.EffectType.Fly,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Create a custom motion effect and attach it to the animation
                var behaviorFactory = new BehaviorFactory();
                var motionEffect = behaviorFactory.CreateMotionEffect();
                effect.Behaviors.Add(motionEffect);

                // Save the presentation
                pres.Save("DemoPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}