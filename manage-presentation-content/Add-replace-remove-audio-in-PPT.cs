using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        // Define file paths
        string inputPath = "input.pptx";
        string audioPath = "sample.wav";
        string outputPath = "output.pptx";

        // Verify input files exist
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation not found.");
            return;
        }
        if (!File.Exists(audioPath))
        {
            Console.WriteLine("Audio file not found.");
            return;
        }

        // Load the presentation
        Presentation pres = new Presentation(inputPath);

        // Add audio to the presentation's audio collection
        IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(audioPath));

        // Add an audio frame to the first slide
        ISlide slide = pres.Slides[0];
        IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);
        audioFrame.PlayAcrossSlides = true;
        audioFrame.RewindAudio = true;
        audioFrame.Volume = AudioVolumeMode.Loud;
        audioFrame.PlayMode = AudioPlayModePreset.Auto;

        // Trim audio start and end
        audioFrame.TrimFromStart = 2000f; // milliseconds
        audioFrame.TrimFromEnd = 3000f;   // milliseconds

        // Set fade in/out durations
        audioFrame.FadeInDuration = 500f;  // milliseconds
        audioFrame.FadeOutDuration = 500f; // milliseconds

        // Demonstrate stopping previous sound on a second slide (if exists)
        if (pres.Slides.Count > 1)
        {
            IEffect firstEffect = pres.Slides[0].Timeline.MainSequence[0];
            IEffect secondEffect = pres.Slides[1].Timeline.MainSequence[0];
            if (firstEffect.Sound != null)
            {
                secondEffect.StopPreviousSound = true;
            }
        }

        // Save the modified presentation
        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}