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