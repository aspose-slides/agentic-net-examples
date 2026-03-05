using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Load the WAV file into a stream
            FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

            // Add an embedded audio frame to the slide
            IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

            // Set audio playback properties
            audioFrame.PlayMode = AudioPlayModePreset.Auto;
            audioFrame.Volume = AudioVolumeMode.Loud;

            // Close the audio stream
            audioStream.Close();

            // Save the presentation
            pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
        }
    }
}