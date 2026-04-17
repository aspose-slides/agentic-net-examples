using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string audioPath = "sample.wav";
        string outputPath = "output.pptx";

        if (!File.Exists(audioPath))
        {
            Console.WriteLine("Audio file not found.");
            return;
        }

        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            var audioStream = new FileStream(audioPath, FileMode.Open, FileAccess.Read);
            var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
            audioStream.Close();

            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            var effect = slide.Timeline.MainSequence.AddEffect(
                audioFrame,
                Aspose.Slides.Animation.EffectType.MediaPlay,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}