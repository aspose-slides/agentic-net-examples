using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbedAudioExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths for the audio file and the output presentation
                string mediaFile = Path.Combine(Environment.CurrentDirectory, "sampleaudio.wav");
                string outPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Add the audio to the presentation's audio collection
                    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(mediaFile));

                    // Embed the audio into a new audio frame on the first slide
                    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10f, 10f, 100f, 100f, audio);

                    // Configure playback options
                    audioFrame.PlayAcrossSlides = true;
                    audioFrame.RewindAudio = true;

                    // Save the presentation
                    pres.Save(outPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}