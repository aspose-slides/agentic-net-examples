using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioFrameSyncExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the WAV audio file to embed
                string audioFilePath = Path.Combine(Environment.CurrentDirectory, "sample.wav");

                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Add the audio to the presentation's audio collection
                    using (FileStream audioStream = new FileStream(audioFilePath, FileMode.Open, FileAccess.Read))
                    {
                        IAudio audio = presentation.Audios.AddAudio(audioStream);

                        // Get the first slide
                        ISlide slide = presentation.Slides[0];

                        // Add an embedded audio frame to the slide
                        IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10f, 10f, 100f, 100f, audio);

                        // Configure playback synchronization settings
                        audioFrame.PlayAcrossSlides = true;                     // Play across all slides
                        audioFrame.RewindAudio = true;                         // Rewind after playing
                        audioFrame.Volume = AudioVolumeMode.Loud;              // Set volume
                        audioFrame.PlayMode = AudioPlayModePreset.Auto;        // Auto play mode
                    }

                    // Save the presentation
                    string outputPath = Path.Combine(Environment.CurrentDirectory, "AudioSyncOutput.pptx");
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}