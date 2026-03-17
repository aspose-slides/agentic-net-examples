using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();

            // Add an audio file to the presentation's audio collection
            var audioData = File.ReadAllBytes("sample.mp3");
            var audio = presentation.Audios.AddAudio(audioData);

            // Insert an audio frame on the first slide
            var slide = presentation.Slides[0];
            var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

            // Configure playback options
            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.OnClick;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Low;

            // Replace the embedded audio with a new one
            var newAudioData = File.ReadAllBytes("newSample.wav");
            var newAudio = presentation.Audios.AddAudio(newAudioData);
            audioFrame.EmbeddedAudio = newAudio;

            // Remove the audio frame from the slide
            slide.Shapes.Remove(audioFrame);

            // Save the presentation
            presentation.Save("AudioDemo_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}