using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using System.IO;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Iterate through all slides in the presentation
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Get the main sequence of animation effects for the current slide
            Aspose.Slides.Animation.ISequence effectsSequence = slide.Timeline.MainSequence;

            // Iterate through each effect in the sequence
            foreach (Aspose.Slides.Animation.IEffect effect in effectsSequence)
            {
                // Skip effects that do not have an associated sound
                if (effect.Sound == null)
                {
                    continue;
                }

                // Extract the embedded audio data as a byte array
                byte[] audioData = effect.Sound.BinaryData;

                // Save the extracted audio to a file (optional)
                string outputFileName = $"slide{slideIndex + 1}_effect_{effect.GetHashCode()}.bin";
                File.WriteAllBytes(outputFileName, audioData);
            }
        }

        // Save the presentation before exiting (even if unchanged)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}