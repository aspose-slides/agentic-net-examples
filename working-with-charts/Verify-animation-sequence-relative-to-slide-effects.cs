using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        Aspose.Slides.IAutoShape rect1 = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 100, 50);
        rect1.AddTextFrame("First");

        Aspose.Slides.IAutoShape rect2 = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 200, 50, 100, 50);
        rect2.AddTextFrame("Second");

        Aspose.Slides.Animation.IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
            rect1,
            Aspose.Slides.Animation.EffectType.Fade,
            Aspose.Slides.Animation.EffectSubtype.None,
            Aspose.Slides.Animation.EffectTriggerType.OnClick);

        Aspose.Slides.Animation.IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
            rect2,
            Aspose.Slides.Animation.EffectType.Fly,
            Aspose.Slides.Animation.EffectSubtype.Left,
            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

        // Verify that the animation sequence order matches the added effects
        Aspose.Slides.Animation.IEffect firstEffect = slide.Timeline.MainSequence[0];
        Aspose.Slides.Animation.IEffect secondEffect = slide.Timeline.MainSequence[1];

        if (firstEffect == effect1 && secondEffect == effect2)
        {
            Console.WriteLine("Animation sequence order is correct.");
        }
        else
        {
            Console.WriteLine("Animation sequence order is incorrect.");
        }

        System.String outputPath = "output.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}