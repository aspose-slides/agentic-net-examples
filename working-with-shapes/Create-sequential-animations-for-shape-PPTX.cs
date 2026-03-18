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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide (default blank slide)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
            ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "Animated Shape";

            // Access the slide's animation timeline
            Aspose.Slides.IAnimationTimeLine timeline = slide.Timeline;

            // Get the main sequence of animations
            Aspose.Slides.Animation.ISequence mainSequence = timeline.MainSequence;

            // Add Fade effect
            mainSequence.AddEffect(shape,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Add Fly effect from left
            mainSequence.AddEffect(shape,
                Aspose.Slides.Animation.EffectType.Fly,
                Aspose.Slides.Animation.EffectSubtype.Left,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Add Zoom effect (zoom in)
            mainSequence.AddEffect(shape,
                Aspose.Slides.Animation.EffectType.Zoom,
                Aspose.Slides.Animation.EffectSubtype.In,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Save the presentation
            presentation.Save("AnimatedPresentation.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}