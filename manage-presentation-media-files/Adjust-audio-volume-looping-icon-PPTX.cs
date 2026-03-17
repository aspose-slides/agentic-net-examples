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
            // Paths for the audio file and the output presentation
            string audioPath = "sampleaudio.wav";
            string outPath = "AdjustedAudio.pptx";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Add the audio to the presentation's audio collection
            IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(audioPath));

            // Add an embedded audio frame to the first slide
            IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);

            // Set audio playback properties
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud; // Adjust volume
            audioFrame.PlayLoopMode = true;                        // Enable looping
            audioFrame.HideAtShowing = true;                       // Hide the audio icon during slide show

            // Save the presentation
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}