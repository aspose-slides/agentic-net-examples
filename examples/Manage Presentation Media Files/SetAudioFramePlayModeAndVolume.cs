using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Load audio file into a byte array
        byte[] audioBytes = System.IO.File.ReadAllBytes("sampleaudio.mp3");

        // Add the audio to the presentation's audio collection
        Aspose.Slides.IAudio audio = pres.Audios.AddAudio(audioBytes);

        // Add an embedded audio frame to the slide
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

        // Set the audio play mode to play on click
        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.OnClick;

        // Set the audio volume to loud
        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

        // Save the presentation
        pres.Save("AudioFrameSettings_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}