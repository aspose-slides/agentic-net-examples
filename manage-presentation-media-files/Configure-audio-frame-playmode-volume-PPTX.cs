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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);
            Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
            audioStream.Dispose();

            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.OnClick;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Low;

            presentation.Save("AudioConfigured.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}