// -----------------------------------------------------------------------------
// Example: Set audio frame start using C#
//
// Description:
// Demonstrates how to set the start position (trim from start) of an audio
// frame in a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example loads a presentation, embeds an audio file, trims the first
// two seconds, and saves the updated file. This pattern can be used to
// control audio playback timing in automated PPTX processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Audio, Frame, TrimFromStart, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Adjust audio playback start time in generated presentations.
// - Build C# tools for precise media timing in PowerPoint files.
// - Automate embedding and trimming of audio in PPTX documents.
// - Validate audio synchronization before publishing.
// -----------------------------------------------------------------------------
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
