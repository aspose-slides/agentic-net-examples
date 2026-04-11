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