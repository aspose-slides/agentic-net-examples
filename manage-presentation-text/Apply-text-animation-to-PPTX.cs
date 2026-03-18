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
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];

            IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
            ITextFrame textFrame = autoShape.AddTextFrame("Hello Aspose Slides!");

            IParagraph paragraph = textFrame.Paragraphs[0];

            IEffect effect = slide.Timeline.MainSequence.AddEffect(
                paragraph,
                Aspose.Slides.Animation.EffectType.Fly,
                Aspose.Slides.Animation.EffectSubtype.Left,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            effect.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;

            presentation.Save("AnimatedText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}