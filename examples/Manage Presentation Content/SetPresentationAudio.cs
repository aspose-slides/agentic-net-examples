using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Load an audio file into a stream (ensure the file exists at the specified path)
                System.IO.FileStream audioStream = new System.IO.FileStream("sample.wav", System.IO.FileMode.Open, System.IO.FileAccess.Read);

                // Add an embedded audio frame to the slide
                Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);

                // Configure audio playback options
                audioFrame.PlayAcrossSlides = true;
                audioFrame.RewindAudio = true;
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
                audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;

                // Close the audio stream
                audioStream.Close();

                // Save the presentation in PPTX format
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}