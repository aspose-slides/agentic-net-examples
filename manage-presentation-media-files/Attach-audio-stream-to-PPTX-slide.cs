using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesAudioEmbed
{
    class Program
    {
        static void Main()
        {
            try
            {
                var presentation = new Presentation();
                var slide = presentation.Slides[0];

                using (var audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read))
                {
                    var audio = presentation.Audios.AddAudio(audioStream);
                    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);
                }

                presentation.Save("AudioEmbedded_out.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}