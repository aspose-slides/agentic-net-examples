using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string audioPath = "sampleaudio.mp3";
            string outputPath = "AudioFrameWithOffset.pptx";

            // Verify that the audio file exists
            if (!File.Exists(audioPath))
            {
                Console.WriteLine("Audio file not found: " + audioPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add the audio to the presentation's audio collection
                IAudio audio = presentation.Audios.AddAudio(File.ReadAllBytes(audioPath));

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add an embedded audio frame to the slide
                IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);

                // Set a custom start time offset (e.g., 2 seconds)
                audioFrame.TrimFromStart = 2000f; // milliseconds

                // Optionally set other playback properties
                audioFrame.PlayAcrossSlides = true;
                audioFrame.RewindAudio = true;
                audioFrame.Volume = AudioVolumeMode.Loud;
                audioFrame.PlayMode = AudioPlayModePreset.Auto;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}