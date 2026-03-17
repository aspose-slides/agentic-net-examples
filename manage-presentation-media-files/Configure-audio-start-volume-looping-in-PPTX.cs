using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for the audio file and the output presentation
            string audioPath = Path.Combine(Environment.CurrentDirectory, "sampleaudio.wav");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "ConfiguredAudio.pptx");

            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add the audio to the presentation's audio collection
                Aspose.Slides.IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(audioPath));

                // Add an embedded audio frame to the slide
                Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10f, 10f, 100f, 100f, audio);

                // Configure playback: start automatically, set loud volume, enable looping
                audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
                audioFrame.PlayLoopMode = true;

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}