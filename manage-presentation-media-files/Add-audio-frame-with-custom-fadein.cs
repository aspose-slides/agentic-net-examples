using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputAudioPath = "sampleaudio.mp3";
        string outputPath = "AudioFadeIn.pptx";

        if (!File.Exists(inputAudioPath))
        {
            Console.WriteLine("Input audio file not found.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            Aspose.Slides.IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(inputAudioPath));
            Aspose.Slides.IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(50f, 50f, 100f, 100f, audio);
            audioFrame.FadeInDuration = 200f; // 200 ms fade-in

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}