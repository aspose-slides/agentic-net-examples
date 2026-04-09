using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesAudioExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the MP3 file
            string audioPath = "sampleaudio.mp3";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Ensure there are at least three slides
                while (pres.Slides.Count < 3)
                {
                    pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
                }

                // Get the third slide (index 2)
                ISlide slide = pres.Slides[2];

                try
                {
                    // Verify that the audio file exists
                    if (!File.Exists(audioPath))
                    {
                        Console.WriteLine("Audio file not found: " + audioPath);
                    }
                    else
                    {
                        // Add an audio frame linked to the MP3 file
                        IAudioFrame audioFrame = slide.Shapes.AddAudioFrameLinked(50, 50, 100, 100, audioPath);

                        // Set the audio to loop continuously
                        audioFrame.PlayLoopMode = true;
                    }

                    // Save the presentation
                    pres.Save("AudioLoopPresentation.pptx", SaveFormat.Pptx);
                }
                catch (PptxUnsupportedFormatException)
                {
                    // Format not supported for PPTX
                    Console.WriteLine("The presentation format is not supported.");
                }
                catch (PptUnsupportedFormatException)
                {
                    // Format not supported for PPT
                    Console.WriteLine("The presentation format is not supported.");
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}