using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace ApplyMultipleEffects
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to the slide
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 150);
                shape.TextFrame.Text = "Animated Shape";

                // Apply Fade effect
                slide.Timeline.MainSequence.AddEffect(
                    shape,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Apply Fly effect
                slide.Timeline.MainSequence.AddEffect(
                    shape,
                    Aspose.Slides.Animation.EffectType.Fly,
                    Aspose.Slides.Animation.EffectSubtype.Left,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Apply Spin effect
                slide.Timeline.MainSequence.AddEffect(
                    shape,
                    Aspose.Slides.Animation.EffectType.Spin,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Save the presentation
                presentation.Save("MultipleEffects.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}