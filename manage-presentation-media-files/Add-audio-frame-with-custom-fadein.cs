// -----------------------------------------------------------------------------
// Example: Add audio frame with custom fadein using C#
//
// Description:
// Demonstrates how to add an audio frame with a custom fade‑in duration using
// C# and Aspose.Slides for .NET. The example creates a new presentation,
// embeds an MP3 audio file, places an audio frame on the first slide, sets a
// 200 ms fade‑in effect, and saves the result as a PPTX file. This pattern can be
// used to automate PowerPoint media handling, validate audio timing, or
// integrate custom audio playback into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Audio, Frame, Custom, Fadein,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding audio frames with custom fade‑in effects.
// - Build C# tools for PowerPoint presentation media processing.
// - Generate or modify PPTX files with embedded audio in .NET applications.
// - Validate audio playback settings before publishing presentations.
// -----------------------------------------------------------------------------

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
