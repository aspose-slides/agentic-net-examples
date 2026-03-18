using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("Hello Aspose Slides!");
            var effect = slide.Timeline.MainSequence.AddEffect(
                shape,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
            effect.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;
            presentation.Save("CustomTextAnimation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}