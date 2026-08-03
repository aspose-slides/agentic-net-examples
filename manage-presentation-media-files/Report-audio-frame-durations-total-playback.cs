// -----------------------------------------------------------------------------
// Example: Report total estimated audio playback duration from audio frames using C#
//
// Description:
// Demonstrates how to calculate an estimated total audio playback duration by
// iterating through all slides and audio frames in a PowerPoint presentation,
// summing fade‑in, fade‑out, trim‑from‑start and trim‑from‑end values. The example
// uses Aspose.Slides for .NET in a console application, handling missing files
// and unsupported formats, and saves the presentation after processing.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, AudioFrame, FadeInDuration,
// FadeOutDuration, TrimFromStart, TrimFromEnd, Presentation Processing,
// Audio Playback Estimation
//
// Use Cases:
// - Generate a quick estimate of total audio playback time in a PPTX.
// - Create automated validation tools for audio timing in presentations.
// - Integrate audio duration reporting into .NET PowerPoint processing pipelines.
// - Ensure audio assets meet duration requirements before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesAudioReport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    double totalPlaybackMs = 0.0;

                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        for (int shapeIndex = 0; shapeIndex < presentation.Slides[slideIndex].Shapes.Count; shapeIndex++)
                        {
                            IShape shape = presentation.Slides[slideIndex].Shapes[shapeIndex];
                            AudioFrame audioFrame = shape as AudioFrame;
                            if (audioFrame != null)
                            {
                                // Approximate playback time by summing fade and trim durations
                                totalPlaybackMs += audioFrame.FadeInDuration;
                                totalPlaybackMs += audioFrame.FadeOutDuration;
                                totalPlaybackMs += audioFrame.TrimFromStart;
                                totalPlaybackMs += audioFrame.TrimFromEnd;
                            }
                        }
                    }

                    Console.WriteLine("Total estimated audio playback time: " + totalPlaybackMs + " ms");

                    // Save the presentation before exiting
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
