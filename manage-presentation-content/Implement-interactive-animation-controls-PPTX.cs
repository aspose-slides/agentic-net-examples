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
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            Aspose.Slides.IShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
            // Add an ellipse shape
            Aspose.Slides.IShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 300, 50, 200, 100);

            // Add a fade effect to the rectangle (main sequence)
            slide.Timeline.MainSequence.AddEffect(
                shape1,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Create an interactive sequence: clicking the rectangle triggers the ellipse to fly in
            Aspose.Slides.Animation.ISequence interactiveSeq = slide.Timeline.InteractiveSequences[0];
            interactiveSeq.TriggerShape = shape1;
            interactiveSeq.AddEffect(
                shape2,
                Aspose.Slides.Animation.EffectType.Fly,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.OnClick);

            // Save the presentation
            presentation.Save("InteractiveAnimations.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}