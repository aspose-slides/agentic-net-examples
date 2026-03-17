using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioManipulationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Load audio data from a WAV file
                byte[] audioBytes = File.ReadAllBytes("sampleaudio.wav");

                // Add the audio to the presentation's audio collection
                Aspose.Slides.IAudio audio = pres.Audios.AddAudio(audioBytes);

                // Add an audio frame to the slide using the embedded audio
                Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);

                // Set playback options for the audio frame
                audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
                audioFrame.PlayAcrossSlides = true;

                // Update the volume to a different level
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Medium;

                // Remove the audio frame from the slide
                slide.Shapes.Remove(audioFrame);

                // Save the presentation
                pres.Save("AudioManipulation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}