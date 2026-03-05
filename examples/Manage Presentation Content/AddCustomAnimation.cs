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

        // Define output path
        System.String outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "CustomAnimation_out.pptx");

        // Add an ellipse shape and set its text
        Aspose.Slides.IAutoShape oval = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 150);
        oval.TextFrame.Text = "Hello World";

        // Get the animation timeline for the first slide
        Aspose.Slides.IAnimationTimeLine timeline = presentation.Slides[0].Timeline;

        // Add an appear effect to the shape
        Aspose.Slides.Animation.IEffect effect = timeline.MainSequence.AddEffect(oval, Aspose.Slides.Animation.EffectType.Appear, Aspose.Slides.Animation.EffectSubtype.None, Aspose.Slides.Animation.EffectTriggerType.OnClick);
        effect.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;
        effect.DelayBetweenTextParts = -1.5f;

        // Save the presentation
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}