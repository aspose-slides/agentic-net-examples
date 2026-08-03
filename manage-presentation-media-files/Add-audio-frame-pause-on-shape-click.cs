// -----------------------------------------------------------------------------
// Example: Add audio frame pause on shape click using C#
//
// Description:
// Demonstrates how to add an embedded audio frame to a slide and configure a
// shape click to pause the audio playback using Aspose.Slides for .NET. The
// example creates a presentation, inserts an audio file, adds a rectangle
// shape as a pause button, and sets an OnClick animation effect that stops the
// previously playing sound.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Audio, Frame, Pause, Shape,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding pause functionality to audio in PowerPoint presentations.
// - Build C# utilities for interactive media control in slides.
// - Generate or modify PPTX files with audio playback controls.
// - Validate audio interaction workflows before deployment.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        string audioPath = Path.Combine(Environment.CurrentDirectory, "sampleaudio.wav");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "AudioPauseOnShapeClick.pptx");

        if (!File.Exists(audioPath))
        {
            Console.WriteLine("Audio file not found: " + audioPath);
            return;
        }

        try
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add an embedded audio frame
                FileStream audioStream = new FileStream(audioPath, FileMode.Open, FileAccess.Read);
                IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
                audioStream.Dispose();

                // Configure audio playback
                audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

                // Add a rectangle shape that will act as the pause button
                IAutoShape pauseShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200f, 150f, 100f, 50f);
                pauseShape.Name = "PauseShape";
                pauseShape.TextFrame.Text = "Pause Audio";

                // Add an effect to the shape with OnClick trigger
                IEffect effect = slide.Timeline.MainSequence.AddEffect(
                    pauseShape,
                    Aspose.Slides.Animation.EffectType.Appear,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.OnClick);

                // Configure the effect to stop (pause) the previous sound
                effect.StopPreviousSound = true;

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
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
