using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
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
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Identify picture frames (images)
                        IPictureFrame picture = shape as IPictureFrame;
                        if (picture != null)
                        {
                            // Add a fade‑out exit animation to the image
                            IEffect effect = slide.Timeline.MainSequence.AddEffect(
                                picture,
                                EffectType.Fade,
                                EffectSubtype.None,
                                EffectTriggerType.AfterPrevious);

                            // Set the animation duration to 2 seconds (2000 ms)
                            effect.Timing.Duration = 2000;
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
            // Handle other exceptions (e.g., external URLs or I/O errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}