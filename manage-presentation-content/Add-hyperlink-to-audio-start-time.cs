// -----------------------------------------------------------------------------
// Example: Add hyperlink to audio start time using C#
//
// Description:
// Demonstrates how to embed an audio file into a slide, set its playback start
// time (trim from start), and add a hyperlink that points to an external audio
// resource using Aspose.Slides for .NET. The example creates a new presentation,
// adds an audio frame, configures its start time, assigns a click hyperlink, and
// saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hyperlink, Audio, Start Time,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate embedding audio with a specific start offset in PowerPoint slides.
// - Add clickable hyperlinks to audio frames for external resources.
// - Build .NET tools for presentation generation and manipulation.
// - Validate audio playback settings programmatically before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputAudioPath = "sampleaudio.wav";
        string outputPath = "output.pptx";

        if (!File.Exists(inputAudioPath))
        {
            Console.WriteLine("Input audio file does not exist.");
            return;
        }

        Presentation pres = null;
        try
        {
            pres = new Presentation();
            ISlide slide = pres.Slides[0];

            FileStream audioStream = new FileStream(inputAudioPath, FileMode.Open, FileAccess.Read);
            IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audioStream);
            audioStream.Close();

            // Set playback start time (trim from start) to 2 seconds (2000 ms)
            audioFrame.TrimFromStart = 2000f;

            // Add hyperlink to external audio file
            IHyperlink hyperlink = new Hyperlink("https://example.com/audio.mp3");
            audioFrame.HyperlinkClick = hyperlink;

            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}
