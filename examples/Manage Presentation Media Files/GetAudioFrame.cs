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

        // Load an audio file (WAV) from disk
        System.IO.FileStream audioStream = new System.IO.FileStream("sampleaudio.wav", System.IO.FileMode.Open, System.IO.FileAccess.Read);

        // Add an embedded audio frame to the slide
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

        // Close the audio stream
        audioStream.Close();

        // Set audio playback properties
        audioFrame.PlayAcrossSlides = true;
        audioFrame.RewindAudio = true;

        // Save the presentation to PPTX format
        presentation.Save("AudioFrameExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}