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
            var presentation = new Presentation();
            var slide = presentation.Slides[0];

            // Add a rectangle shape with text
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
            shape.TextFrame.Text = "Animated Shape";

            // Access the slide's animation timeline
            var timeline = slide.Timeline;

            // Get the main animation sequence
            var mainSequence = timeline.MainSequence;

            // Add a Fly animation effect to the shape
            var effect = mainSequence.AddEffect(shape, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.AfterPrevious);

            // Set precise timing: start after 0.5 seconds, duration 2 seconds
            effect.Timing.TriggerDelayTime = 0.5f; // seconds
            effect.Timing.Duration = 2.0f; // seconds

            // Set slide transition duration to 3 seconds (3000 ms)
            slide.SlideShowTransition.Duration = 3000;

            // Enable using timings in the slide show
            presentation.SlideShowSettings.UseTimings = true;

            // Save the presentation
            presentation.Save("SetAnimationTiming_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}