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
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            // Load audio file bytes (ensure the file exists at the specified path)
            var audioData = File.ReadAllBytes("sampleaudio.wav");
            var audio = presentation.Audios.AddAudio(audioData);

            // Add an embedded audio frame to the slide
            var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audio);

            // Set playback options
            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            // Save the presentation
            presentation.Save("AudioEmbedded.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}