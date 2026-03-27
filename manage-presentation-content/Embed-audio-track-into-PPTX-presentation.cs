using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioEmbedExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input audio file (WAV) and output presentation paths
            string audioPath = "sampleaudio.wav";
            string outputPath = "AudioEmbedded.pptx";

            // Verify that the audio file exists
            if (!File.Exists(audioPath))
            {
                Console.WriteLine("Audio file not found: " + audioPath);
                return;
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Open the audio file as a stream
            FileStream audioStream = new FileStream(audioPath, FileMode.Open, FileAccess.Read, FileShare.Read);

            // Add an embedded audio frame to the slide
            Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

            // Configure audio playback settings
            audioFrame.PlayAcrossSlides = true;
            audioFrame.RewindAudio = true;
            audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
            audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;

            // Close the audio stream
            audioStream.Close();

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}