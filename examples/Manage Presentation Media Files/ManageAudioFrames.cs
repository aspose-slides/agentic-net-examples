using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            Aspose.Slides.ISlide slide = pres.Slides[0];
            using (FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
                audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
                audioFrame.PlayAcrossSlides = true;
                audioFrame.RewindAudio = true;
            }
            pres.Save("AudioFrameExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}