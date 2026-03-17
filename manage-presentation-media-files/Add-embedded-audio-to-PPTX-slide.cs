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
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Load WAV audio file into a FileStream
                FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

                // Add embedded audio frame
                IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

                // Set playback options
                audioFrame.PlayMode = AudioPlayModePreset.Auto;
                audioFrame.Volume = AudioVolumeMode.Loud;

                // Close the audio stream
                audioStream.Close();

                // Save the presentation
                presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}