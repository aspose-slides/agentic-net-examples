// -----------------------------------------------------------------------------
// Example: Set audio frame volume and autoplay using C#
//
// Description:
// Demonstrates how to embed an audio file into a slide, set the audio frame
// volume, and configure the frame to autoplay using C# and Aspose.Slides for
// .NET. The example creates a new presentation, adds an audio frame with a
// specified volume level, sets the playback mode to automatic, and saves the
// result as a PPTX file.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Audio, AudioFrame, Volume,
// Autoplay, Presentation Processing, Office Automation
//
// Use Cases:
// - Embed audio into a PowerPoint slide programmatically.
// - Adjust audio playback volume in generated presentations.
// - Configure audio frames to start automatically when the slide is shown.
// - Automate creation of PPTX files with embedded media for .NET applications.
// -----------------------------------------------------------------------------

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
