using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input audio file and output presentation paths
        string inputAudioPath = Path.Combine(Environment.CurrentDirectory, "sample.wav");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        // Verify that the audio file exists
        if (!File.Exists(inputAudioPath))
        {
            Console.WriteLine("Audio file not found: " + inputAudioPath);
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add the audio file to the presentation's audio collection
            Aspose.Slides.IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(inputAudioPath));

            // Loop to add audio frames to multiple slides
            for (int i = 0; i < 5; i++)
            {
                // Add a new empty slide based on the first layout slide
                Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

                // Add an embedded audio frame to the slide
                Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);
                audioFrame.PlayAcrossSlides = true;
                audioFrame.RewindAudio = true;
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
                audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
            }

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
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