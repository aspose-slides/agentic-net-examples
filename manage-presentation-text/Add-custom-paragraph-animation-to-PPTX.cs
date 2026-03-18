using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace SlideParagraphAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a blank slide
                ISlide slide = presentation.Slides[0];

                // Add an AutoShape with some text
                IAutoShape autoShape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
                autoShape.AddTextFrame("First paragraph.\nSecond paragraph.\nThird paragraph.");

                // Get the main animation sequence
                ISequence mainSequence = slide.Timeline.MainSequence;

                // Apply a Fly effect to each paragraph individually
                for (int i = 0; i < autoShape.TextFrame.Paragraphs.Count; i++)
                {
                    IParagraph paragraph = autoShape.TextFrame.Paragraphs[i];
                    mainSequence.AddEffect(paragraph,
                        Aspose.Slides.Animation.EffectType.Fly,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                }

                // Save the presentation
                presentation.Save("ParagraphAnimationOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}