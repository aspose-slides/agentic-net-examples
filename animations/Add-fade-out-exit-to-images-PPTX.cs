using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace FadeOutImagesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Apply only to picture (image) shapes
                        if (shape is IPictureFrame)
                        {
                            // Add a fade-out exit animation effect
                            IEffect effect = slide.Timeline.MainSequence.AddEffect(
                                shape,
                                EffectType.Fade,
                                EffectSubtype.None,
                                EffectTriggerType.AfterPrevious);

                            // Set the duration of the effect to 2 seconds (2000 ms)
                            // Note: Timing.Duration is in milliseconds
                            effect.Timing.Duration = 2000;
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., loading errors, web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}