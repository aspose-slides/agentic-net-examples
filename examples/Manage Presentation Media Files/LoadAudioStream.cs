using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the audio file stream (WAV format)
        FileStream audioStream = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add the audio to the presentation's audio collection
        Aspose.Slides.IAudio audio = pres.Audios.AddAudio(audioStream);

        // Add an audio frame to the slide using the embedded audio
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);

        // Save the presentation
        pres.Save("AudioEmbedded.pptx", SaveFormat.Pptx);

        // Clean up resources
        audioStream.Close();
        pres.Dispose();
    }
}