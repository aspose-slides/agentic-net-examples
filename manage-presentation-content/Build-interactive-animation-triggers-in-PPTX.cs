using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Define output file path
                string outPath = Path.Combine(Directory.GetCurrentDirectory(), "AnimatedEllipse_out.pptx");

                // Add an ellipse auto shape to the first slide
                Aspose.Slides.IAutoShape oval = (Aspose.Slides.IAutoShape)presentation.Slides[0].Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 150);

                // Add a text frame and set its text
                oval.AddTextFrame("Animated Text");

                // Get the animation timeline of the first slide
                Aspose.Slides.IAnimationTimeLine timeline = presentation.Slides[0].Timeline;

                // Add an appear effect to the shape
                Aspose.Slides.Animation.IEffect effect = timeline.MainSequence.AddEffect(
                    oval,
                    Aspose.Slides.Animation.EffectType.Appear,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.OnClick);

                // Animate the text by letter
                effect.AnimateTextType = Aspose.Slides.Animation.AnimateTextType.ByLetter;

                // Set a negative delay between text parts (seconds)
                effect.DelayBetweenTextParts = -1.5f;

                // Save the presentation
                presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}