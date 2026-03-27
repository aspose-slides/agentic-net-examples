using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Define output file path
        string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "AnimatedText.pptx");

        // Add an ellipse shape with text
        IAutoShape oval = (IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 150);
        oval.TextFrame.Text = "Animated Text Example";

        // Get the animation timeline of the first slide
        IAnimationTimeLine timeline = presentation.Slides[0].Timeline;

        // Add an appear effect to the shape
        IEffect effect = timeline.MainSequence.AddEffect(oval, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.AnimateTextType = AnimateTextType.ByLetter;
        effect.DelayBetweenTextParts = -1.5f;

        // Save the presentation
        presentation.Save(outPath, SaveFormat.Pptx);
    }
}