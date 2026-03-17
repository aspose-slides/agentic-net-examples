using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AnimatedTextDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                var presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                var slide = presentation.Slides[0];

                // Add a rectangle auto shape with a text frame
                var autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
                autoShape.AddTextFrame("Animated Text");

                // Add a Fly animation effect to the shape
                var effect = slide.Timeline.MainSequence.AddEffect(
                    autoShape,
                    Aspose.Slides.Animation.EffectType.Fly,
                    Aspose.Slides.Animation.EffectSubtype.Left,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Set the text animation type to animate by letter
                effect.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;

                // Save the presentation
                presentation.Save("AnimatedText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}