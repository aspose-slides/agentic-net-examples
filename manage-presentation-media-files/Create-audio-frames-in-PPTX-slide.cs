using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioFramesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths for the audio file and the output presentation
                string audioFilePath = Path.Combine(Environment.CurrentDirectory, "sampleaudio.wav");
                string outputPath = Path.Combine(Environment.CurrentDirectory, "AudioFramesOutput.pptx");

                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Add the audio file to the presentation's audio collection
                    byte[] audioData = File.ReadAllBytes(audioFilePath);
                    IAudio audio = pres.Audios.AddAudio(audioData);

                    // Get the first slide
                    ISlide slide = pres.Slides[0];

                    // Add an embedded audio frame at the specified position and size
                    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);

                    // Configure playback options for the audio frame
                    audioFrame.PlayAcrossSlides = true;
                    audioFrame.RewindAudio = true;
                    audioFrame.Volume = AudioVolumeMode.Loud;
                    audioFrame.PlayMode = AudioPlayModePreset.Auto;

                    // Save the presentation
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation created successfully at: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}