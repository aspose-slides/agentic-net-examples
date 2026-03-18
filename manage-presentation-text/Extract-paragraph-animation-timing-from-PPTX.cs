using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace ExtractParagraphAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    Aspose.Slides.ISlideShowTransition transition = slide.SlideShowTransition;

                    // Output slide transition properties
                    Console.WriteLine($"Slide {slideIndex + 1} Transition:");
                    Console.WriteLine($"  Type: {transition.Type}");
                    Console.WriteLine($"  AdvanceOnClick: {transition.AdvanceOnClick}");
                    Console.WriteLine($"  AdvanceAfter: {transition.AdvanceAfter}");
                    Console.WriteLine($"  AdvanceAfterTime (ms): {transition.AdvanceAfterTime}");
                    Console.WriteLine($"  Duration (ms): {transition.Duration}");

                    // Get the animation timeline for the slide
                    Aspose.Slides.IAnimationTimeLine timeline = slide.Timeline;
                    Aspose.Slides.Animation.ISequence mainSequence = timeline.MainSequence;

                    // Iterate through shapes to find AutoShapes with text
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IAutoShape autoShape = slide.Shapes[shapeIndex] as Aspose.Slides.IAutoShape;
                        if (autoShape == null || autoShape.TextFrame == null)
                            continue;

                        // Iterate through paragraphs in the text frame
                        for (int paragraphIndex = 0; paragraphIndex < autoShape.TextFrame.Paragraphs.Count; paragraphIndex++)
                        {
                            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                            // Retrieve effects applied to this paragraph
                            Aspose.Slides.Animation.IEffect[] paragraphEffects = mainSequence.GetEffectsByParagraph(paragraph);
                            if (paragraphEffects == null || paragraphEffects.Length == 0)
                                continue;

                            foreach (Aspose.Slides.Animation.IEffect effect in paragraphEffects)
                            {
                                // Output effect details
                                Console.WriteLine($"  Paragraph {paragraphIndex + 1} Effect:");
                                Console.WriteLine($"    Type: {effect.Type}");
                                Console.WriteLine($"    Subtype: {effect.Subtype}");
                                Console.WriteLine($"    TriggerDelayTime (s): {effect.Timing.TriggerDelayTime}");
                            }
                        }
                    }
                }

                // Save the presentation (required by lifecycle rule)
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}