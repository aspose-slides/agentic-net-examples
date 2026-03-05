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

        // Load a WAV audio file into a stream
        FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

        // Add an embedded audio frame to the slide
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);

        // Set playback options for the audio frame
        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
        audioFrame.PlayAcrossSlides = true;
        audioFrame.PlayLoopMode = false;
        audioFrame.HideAtShowing = true;
        audioFrame.RewindAudio = true;

        // Close the audio stream
        audioStream.Close();

        // Save the presentation
        presentation.Save("AudioPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}