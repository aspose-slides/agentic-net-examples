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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Open WAV audio file stream
            FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

            // Add embedded audio frame to the slide
            Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

            // Configure playback settings
            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
            audioFrame.PlayAcrossSlides = true;
            audioFrame.PlayLoopMode = false;
            audioFrame.HideAtShowing = false;
            audioFrame.RewindAudio = true;

            // Close the audio stream
            audioStream.Close();

            // Save the presentation
            presentation.Save("EmbeddedAudioPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}