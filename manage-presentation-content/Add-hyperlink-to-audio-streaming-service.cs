// -----------------------------------------------------------------------------
// Example: Add hyperlink to audio streaming service using C#
//
// Description:
// Demonstrates how to embed an audio file into a PowerPoint presentation and
// attach a hyperlink that points to an external audio streaming service using
// Aspose.Slides for .NET. The example creates a new presentation, adds an
// embedded audio frame, configures a click‑action hyperlink, and saves the
// resulting PPTX file. This pattern can be used to automate PPTX workflows that
// require linking embedded media to online streaming resources.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hyperlink, Audio, Streaming,
// Service, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding hyperlinks to embedded audio that reference streaming services.
// - Build C# tools for PowerPoint presentation processing with media integration.
// - Generate or transform PPTX files that combine local audio assets with online links.
// - Validate presentation workflows involving media playback before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddAudioHyperlinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the audio file to embed
            string audioFilePath = "sample.mp3";

            // Verify that the audio file exists
            if (!File.Exists(audioFilePath))
            {
                Console.WriteLine("Audio file not found: " + audioFilePath);
                return;
            }

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Add the audio to the presentation's audio collection
                IAudio audio = presentation.Audios.AddAudio(File.ReadAllBytes(audioFilePath));

                // Add an audio frame to the first slide and embed the audio
                IAudioFrame audioFrame = presentation.Slides[0].Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

                // Create a hyperlink that points to a streaming service
                Hyperlink hyperlink = new Hyperlink("https://www.streamingservice.com/track/12345");
                hyperlink.Tooltip = "Play on Streaming Service";

                // Assign the hyperlink to the audio frame click action
                audioFrame.HyperlinkClick = hyperlink;

                // Save the presentation
                try
                {
                    presentation.Save("AudioWithHyperlink.pptx", SaveFormat.Pptx);
                }
                catch (NotSupportedException ex)
                {
                    // Handle unsupported format exception
                    Console.WriteLine("The requested save format is not supported: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);
                }
            }
        }
    }
}
