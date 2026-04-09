using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths
        string inputPath = "input.pptx";
        string audioPath = "sampleaudio.wav";
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

        // Load presentation
        Aspose.Slides.Presentation pres = null;
        try
        {
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Get first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add audio frame
        FileStream audioStream = new FileStream(audioPath, FileMode.Open, FileAccess.Read, FileShare.Read);
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
        audioStream.Close();

        // Set playback start time (trim from start) to 2000 ms (2 seconds)
        audioFrame.TrimFromStart = 2000f;

        // Save presentation
        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }

        // Clean up
        pres.Dispose();
    }
}