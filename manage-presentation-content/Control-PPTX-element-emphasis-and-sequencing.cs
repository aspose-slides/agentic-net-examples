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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape
                Aspose.Slides.IShape shape1 = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                // Add an ellipse shape
                Aspose.Slides.IShape shape2 = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 300, 150, 150, 150);

                // Apply a Fade effect to the rectangle on click
                slide.Timeline.MainSequence.AddEffect(
                    shape1,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.OnClick);

                // Apply a Fly effect to the ellipse after the previous effect
                slide.Timeline.MainSequence.AddEffect(
                    shape2,
                    Aspose.Slides.Animation.EffectType.Fly,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Save the presentation
                presentation.Save("EmphasisSequence.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}