using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputAudioPath = "sample.wav";
        var outputPath = "output.pptx";

        if (!File.Exists(inputAudioPath))
        {
            Console.WriteLine("Audio file not found.");
            return;
        }

        try
        {
            using (var pres = new Presentation())
            {
                var slide = pres.Slides[0];
                using (var audioStream = new FileStream(inputAudioPath, FileMode.Open, FileAccess.Read))
                {
                    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
                    audioFrame.PlayAcrossSlides = false; // stop playback on slide transition
                    audioFrame.RewindAudio = true;
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}