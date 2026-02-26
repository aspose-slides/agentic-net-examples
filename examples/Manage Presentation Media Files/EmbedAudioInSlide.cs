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
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Load the audio file into a stream
                FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

                // Add the audio to the presentation's audio collection
                IAudio audio = presentation.Audios.AddAudio(audioStream);

                // Add an audio frame to the slide using the embedded audio
                IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);

                // Optionally set playback properties (example)
                audioFrame.PlayMode = AudioPlayModePreset.Auto;
                audioFrame.Volume = AudioVolumeMode.Loud;

                // Save the presentation
                presentation.Save("AudioEmbedded.pptx", SaveFormat.Pptx);

                // Close the audio stream
                audioStream.Close();
            }
        }
    }
}