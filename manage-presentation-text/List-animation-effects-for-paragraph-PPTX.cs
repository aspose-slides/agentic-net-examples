using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AnimationEffectLister
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";

                using (var presentation = new Presentation(inputPath))
                {
                    // Select the first slide, first shape, first paragraph
                    var slide = presentation.Slides[0];
                    var autoShape = slide.Shapes[0] as IAutoShape;
                    if (autoShape == null || autoShape.TextFrame == null)
                    {
                        Console.WriteLine("No auto shape with text found on the first slide.");
                        return;
                    }

                    var paragraph = autoShape.TextFrame.Paragraphs[0];

                    // Retrieve effects applied to the paragraph
                    var mainSequence = slide.Timeline.MainSequence;
                    var effects = mainSequence.GetEffectsByParagraph(paragraph);

                    Console.WriteLine($"Found {effects.Length} animation effect(s) on the selected paragraph:");
                    foreach (var effect in effects)
                    {
                        Console.WriteLine($"- Type: {effect.Type}, Subtype: {effect.Subtype}");
                    }

                    // Save the presentation (even if unchanged) before exiting
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}