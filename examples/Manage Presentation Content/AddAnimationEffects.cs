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

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);

        // Access the main animation sequence of the slide
        Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;

        // Add a Fade effect to the shape that triggers on click
        Aspose.Slides.Animation.IEffect effect = mainSequence.AddEffect(
            shape,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        // Set the after animation behavior (optional)
        effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.HideOnNextMouseClick;

        // Save the presentation to a PPTX file
        presentation.Save("AnimatedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}