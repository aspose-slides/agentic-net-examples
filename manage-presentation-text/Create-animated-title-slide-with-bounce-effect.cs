using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AnimatedTitleSlide
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape for the title
                IAutoShape titleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 100);
                titleShape.AddTextFrame("Welcome to Aspose Slides");

                // Add an appear effect with ByWord animation
                IEffect effect = slide.Timeline.MainSequence.AddEffect(
                    titleShape,
                    EffectType.Appear,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);
                effect.AnimateTextType = AnimateTextType.ByWord;
                effect.DelayBetweenTextParts = -0.5f; // 0.5 seconds between words

                // Save the presentation
                string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "AnimatedTitle.pptx");
                presentation.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}