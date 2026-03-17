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
            var presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Load audio file into a stream
            using var audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

            // Add an audio frame to the slide
            var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);

            // Configure playback mode and volume
            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            // Save the presentation
            presentation.Save("AudioFrameConfigured.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}