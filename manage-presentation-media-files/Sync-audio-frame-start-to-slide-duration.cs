// -----------------------------------------------------------------------------
// Example: Sync audio frame start to slide duration using C#
//
// Description:
// Demonstrates how to embed an audio file into a slide, configure its playback
// settings, and synchronize slide transition durations with the audio start
// using Aspose.Slides for .NET. The example sets slide transition timing, fade
// effects, and audio playback options to ensure the audio begins with the first
// slide and continues across subsequent slides.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Sync, Audio, Frame, Start, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate embedding and syncing of narration audio with slide timings.
// - Build C# tools for PowerPoint presentation processing that require precise
//   audio‑slide coordination.
// - Generate or transform PPTX files with consistent audio playback across
//   slides in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var inputPresentationPath = "input.pptx";
        var audioPath = "narration.mp3";
        var outputPath = "output.pptx";

        // Verify input files exist
        if (!File.Exists(inputPresentationPath))
        {
            Console.WriteLine("Input presentation not found.");
            return;
        }

        if (!File.Exists(audioPath))
        {
            Console.WriteLine("Audio file not found.");
            return;
        }

        try
        {
            var pres = new Presentation(inputPresentationPath);

            // Add audio to the first slide
            var audioData = File.ReadAllBytes(audioPath);
            var audio = pres.Audios.AddAudio(audioData);
            var slide0 = pres.Slides[0];
            var audioFrame = slide0.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);
            audioFrame.PlayAcrossSlides = true;
            audioFrame.RewindAudio = true;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;

            // Set fade in/out durations
            audioFrame.FadeInDuration = 200f;
            audioFrame.FadeOutDuration = 500f;

            // Synchronize slide transitions with audio (example: 3 seconds per slide)
            var slideDurationMs = 3000f;
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                var slide = pres.Slides[i];
                slide.SlideShowTransition.AdvanceOnClick = false;
                slide.SlideShowTransition.AdvanceAfterTime = (uint)slideDurationMs;
                slide.SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URL issues)
        }
    }
}
