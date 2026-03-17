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

            // Add an embedded audio frame from a WAV file
            using (var audioStream = new FileStream("sample.wav", FileMode.Open, FileAccess.Read))
            {
                var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
                // Modify audio frame properties
                audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
                audioFrame.HideAtShowing = true;
                audioFrame.RewindAudio = true;
            }

            // Add a linked audio frame
            var linkedAudioFrame = slide.Shapes.AddAudioFrameLinked(200, 150, 100, 100, "sample.mp3");
            linkedAudioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.OnClick;

            // Remove the first audio frame from the slide
            var firstAudioFrame = (Aspose.Slides.IAudioFrame)slide.Shapes[0];
            slide.Shapes.Remove(firstAudioFrame);

            // Save the presentation
            presentation.Save("AudioFramesDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}