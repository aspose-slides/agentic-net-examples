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
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape with text
            IAutoShape autoShape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
            autoShape.TextFrame.Text = "Animated Text";

            // Add a fade effect to the shape
            IEffect effect = slide.Timeline.MainSequence.AddEffect(
                autoShape,
                Aspose.Slides.Animation.EffectType.Fade,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            // Set after animation type to hide on next mouse click
            effect.AfterAnimationType = Aspose.Slides.Animation.AfterAnimationType.HideOnNextMouseClick;

            // Save the presentation
            presentation.Save("CustomAnimation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}