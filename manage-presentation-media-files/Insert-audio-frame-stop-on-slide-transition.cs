// -----------------------------------------------------------------------------
// Example: Insert audio frame stop on slide transition using C#
//
// Description:
// Demonstrates how to insert an embedded audio frame into a slide that stops
// playback when the slide transitions, using C# and Aspose.Slides for .NET.
// The example creates a new presentation, adds an audio frame from a local
// WAV file, configures it to not play across slides, and saves the result as a
// PPTX file. This pattern can be used to automate PowerPoint media handling
// in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Audio, Frame, Stop,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of audio frames that stop on slide transition.
// - Build C# tools for managing media playback behavior in PowerPoint files.
// - Generate or modify PPTX presentations with specific audio playback settings.
// - Validate and test presentation media workflows before deployment.
// -----------------------------------------------------------------------------

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

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
