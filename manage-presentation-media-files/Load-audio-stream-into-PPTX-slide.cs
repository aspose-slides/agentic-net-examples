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
            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = pres.Slides[0];

                    // Load the WAV audio file into a stream
                    using (FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read))
                    {
                        // Embed the audio as an audio frame on the slide
                        IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
                        // Optional: set playback mode and volume
                        audioFrame.PlayMode = AudioPlayModePreset.Auto;
                        audioFrame.Volume = AudioVolumeMode.Loud;
                    }

                    // Save the presentation
                    pres.Save("AudioEmbedded.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}