using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

        // Add a fade animation effect to the shape
        Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(shape, Aspose.Slides.Animation.EffectType.Fade, Aspose.Slides.Animation.EffectSubtype.None, 0);

        // Set the duration of the animation effect (in seconds)
        effect.Timing.Duration = 2.0f;

        // Save the presentation
        presentation.Save("AnimationDuration.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}