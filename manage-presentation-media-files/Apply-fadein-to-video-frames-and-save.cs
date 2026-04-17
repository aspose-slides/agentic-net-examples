using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FadeInVideoFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // format not supported
                return;
            }

            // Iterate through all slides and shapes
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];
                    // Apply fade‑in to audio frames (example usage)
                    IAudioFrame audioFrame = shape as IAudioFrame;
                    if (audioFrame != null)
                    {
                        audioFrame.FadeInDuration = 200f; // 200 ms fade‑in
                    }

                    // Video frames do not have a FadeInDuration property.
                    // If needed, other video properties can be set here.
                }
            }

            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}