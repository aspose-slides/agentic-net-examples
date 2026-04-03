using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Util;

namespace SlideAnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (ISlide slide in presentation.Slides)
                    {
                        // Find all title placeholder shapes on the slide
                        IShape[] titleShapes = SlideUtil.FindShapesByPlaceholderType(slide, PlaceholderType.Title);
                        if (titleShapes != null)
                        {
                            // Add fade‑in animation to each title placeholder
                            foreach (IShape shape in titleShapes)
                            {
                                IEffect effect = slide.Timeline.MainSequence.AddEffect(
                                    shape,
                                    EffectType.Fade,
                                    EffectSubtype.None,
                                    EffectTriggerType.OnClick);
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}