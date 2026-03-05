using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an audio frame linked to a file (ensure the file exists at the specified path)
        string audioPath = "sampleaudio.wav";
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameLinked(50, 50, 100, 100, audioPath);

        // Set playback mode to play on click
        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.OnClick;

        // Set the volume to low
        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Low;

        // Set the audio to play across slides
        audioFrame.PlayAcrossSlides = true;

        // Disable looping for the audio
        audioFrame.PlayLoopMode = false;

        // Hide the audio icon during the slide show
        audioFrame.HideAtShowing = true;

        // Rewind the audio to start after playing
        audioFrame.RewindAudio = true;

        // Set the audio volume to 85%
        audioFrame.VolumeValue = 85f;

        // Save the presentation
        presentation.Save("AudioOptionsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}