using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input audio and output presentation
        string audioPath = Path.Combine(Directory.GetCurrentDirectory(), "sampleaudio.wav");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "AddAudioFrame_out.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Open the audio file as a stream
        FileStream audioStream = new FileStream(audioPath, FileMode.Open, FileAccess.Read, FileShare.Read);

        // Add an embedded audio frame to the slide
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

        // Configure audio playback settings
        audioFrame.PlayAcrossSlides = true;
        audioFrame.RewindAudio = true;
        audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
        audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;

        // Close the audio stream
        audioStream.Close();

        // Save the presentation (required before exit)
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}