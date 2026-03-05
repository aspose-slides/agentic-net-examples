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

        // Load audio file into a byte array
        string audioPath = "sampleaudio.wav";
        byte[] audioBytes = File.ReadAllBytes(audioPath);

        // Add the audio to the presentation's shared audio collection
        Aspose.Slides.IAudio sharedAudio = presentation.Audios.AddAudio(audioBytes);

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an audio frame to the slide using the shared audio
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, sharedAudio);
        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}