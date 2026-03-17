using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                using (FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read))
                {
                    Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
                    audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
                    audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
                }
                presentation.Save("AudioFrameEmbed_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}