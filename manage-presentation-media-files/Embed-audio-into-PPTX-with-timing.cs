using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioEmbeddingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input audio file and output presentation
            string inputAudioPath = "sampleaudio.wav";
            string outputPresentationPath = "AudioPresentation.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Open the audio file as a stream
                System.IO.FileStream audioStream = new System.IO.FileStream(
                    inputAudioPath,
                    System.IO.FileMode.Open,
                    System.IO.FileAccess.Read,
                    System.IO.FileShare.Read);

                // Add an embedded audio frame to the slide
                Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(
                    50f,   // X position
                    150f,  // Y position
                    100f,  // Width
                    100f,  // Height
                    audioStream);

                // Close the audio stream as it is no longer needed
                audioStream.Close();

                // Configure playback options
                audioFrame.PlayAcrossSlides = true;                     // Play across all slides
                audioFrame.RewindAudio = true;                         // Rewind after playing
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud; // Set volume to loud
                audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto; // Auto play

                // Save the presentation
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                // Dispose the presentation to release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}