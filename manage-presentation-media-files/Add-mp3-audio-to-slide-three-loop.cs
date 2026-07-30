// -----------------------------------------------------------------------------
// Example: Add mp3 audio to slide three loop using C#
//
// Description:
// Demonstrates how to add an MP3 audio file to the third slide of a PowerPoint
// presentation and configure it to loop continuously using C# and Aspose.Slides
// for .NET. The example creates a new presentation, ensures at least three slides
// exist, adds a linked audio frame to the third slide, sets the loop mode, and
// saves the result as a PPTX file. This pattern can be used to automate audio
// insertion and playback settings in PPTX workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Audio, Slide, Three, Loop,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding MP3 audio to the third slide with looping playback.
// - Build C# tools for PowerPoint presentation processing that include media.
// - Generate or transform PPTX files with embedded audio in .NET applications.
// - Validate presentation workflows involving audio before publishing or integration.
// -----------------------------------------------------------------------------
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
