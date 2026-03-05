using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Open the WAV audio file as a stream
        using (FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read))
        {
            // Add an embedded audio frame to the slide
            Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

            // Set audio playback properties
            audioFrame.PlayMode = AudioPlayModePreset.Auto;
            audioFrame.Volume = AudioVolumeMode.Loud;
        }

        // Save the presentation in PPTX format
        presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
    }
}