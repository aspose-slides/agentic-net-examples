using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths for audio file and output presentation
                string dataDir = Directory.GetCurrentDirectory();
                string audioPath = Path.Combine(dataDir, "sampleaudio.mp3");
                string outputPath = Path.Combine(dataDir, "ModifiedAudio.pptx");

                // Create a new presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    // Add audio to the presentation
                    Aspose.Slides.IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(audioPath));

                    // Get the first slide
                    Aspose.Slides.ISlide slide = pres.Slides[0];

                    // Add an embedded audio frame to the slide
                    Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);

                    // Set playback start behavior to automatic
                    audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;

                    // Enable looping of the audio
                    audioFrame.PlayLoopMode = true;

                    // Set audio volume to loud
                    audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}