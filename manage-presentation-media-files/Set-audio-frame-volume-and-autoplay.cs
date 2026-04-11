using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string audioPath = "sampleaudio.wav";
        string outputPath = "AudioFrameVolume_out.pptx";

        if (!File.Exists(audioPath))
        {
            Console.WriteLine("Audio file not found.");
            return;
        }

        try
        {
            Presentation pres = new Presentation();
            IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(audioPath));
            IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);
            audioFrame.VolumeValue = 75f;
            audioFrame.PlayMode = AudioPlayModePreset.Auto;
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}