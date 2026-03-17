using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Util;

namespace AnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the input and output presentation files
            string dataDir = "C:\\Presentations\\";
            string inputPath = System.IO.Path.Combine(dataDir, "input.pptx");
            string outputPath = System.IO.Path.Combine(dataDir, "output.pptx");

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Locate the shape with alternative text "TargetShape" on the first slide
                    IShape targetShape = SlideUtil.FindShape(presentation.Slides[0], "TargetShape");

                    if (targetShape != null)
                    {
                        // Apply an entrance Fade animation that starts after the previous effect
                        IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
                            targetShape,
                            Aspose.Slides.Animation.EffectType.Fade,
                            Aspose.Slides.Animation.EffectSubtype.None,
                            Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}