// -----------------------------------------------------------------------------
// Example: Add audio to slide after previous using C#
//
// Description:
// Demonstrates how to add an audio file to a slide and configure it to play
// automatically after the previous animation using C# and Aspose.Slides for .NET.
// The example creates a new presentation, embeds an audio file, sets playback
// options, adds a media play effect with an AfterPrevious trigger, and saves the
// result as a PPTX file. This pattern can be used to automate PowerPoint
// workflows, validate audio timing, or integrate audio handling into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Audio, Slide, After, Previous,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding audio to a slide with an AfterPrevious trigger.
// - Build C# tools for PowerPoint presentation processing that include media.
// - Generate or transform PPTX files with embedded audio in .NET applications.
// - Validate presentation workflows involving audio playback before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string audioPath = "sample.wav";
        string outputPath = "output.pptx";

        if (!File.Exists(audioPath))
        {
            Console.WriteLine("Audio file not found.");
            return;
        }

        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            var audioStream = new FileStream(audioPath, FileMode.Open, FileAccess.Read);
            var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
            audioStream.Close();

            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

            var effect = slide.Timeline.MainSequence.AddEffect(
                audioFrame,
                Aspose.Slides.Animation.EffectType.MediaPlay,
                Aspose.Slides.Animation.EffectSubtype.None,
                Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
