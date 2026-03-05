using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Open the WAV audio file as a stream
        System.IO.FileStream audioStream = new System.IO.FileStream("sampleaudio.wav", System.IO.FileMode.Open, System.IO.FileAccess.Read);

        // Add an embedded audio frame to the slide
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

        // Set playback mode and volume
        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

        // Close the audio stream
        audioStream.Close();

        // Save the presentation
        pres.Save("AudioFrameEmbed_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}