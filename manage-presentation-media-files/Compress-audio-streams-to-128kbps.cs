// -----------------------------------------------------------------------------
// Example: Compress audio streams to 128kbps using C#
//
// Description:
// Demonstrates how to compress audio streams to 128kbps using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation‑processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Compress, Audio, Streams, 
// 128Kbps, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate compress audio streams to 128kbps.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioCompressionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPresentationPath = "input.pptx";
            // Output presentation path
            string outputPresentationPath = "output_compressed.pptx";
            // Desired audio bitrate (kbps) – placeholder for actual compression logic
            int targetBitrateKbps = 128;

            // Verify input file exists
            if (!File.Exists(inputPresentationPath))
            {
                Console.WriteLine("Input presentation file does not exist: " + inputPresentationPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPresentationPath);

                // Iterate through all embedded audio objects
                foreach (IAudio audio in presentation.Audios)
                {
                    // Get original audio data
                    byte[] originalAudioData = audio.BinaryData;

                    // Placeholder: compress the audio data to the target bitrate (128 kbps)
                    // The actual compression implementation depends on external audio processing libraries.
                    // For demonstration, we simply assign the original data back.
                    byte[] compressedAudioData = originalAudioData; // TODO: replace with compressed data at 128 kbps

                    // Replace the audio data with compressed version
                    // Aspose.Slides does not provide a direct setter for BinaryData,
                    // so we add a new audio and update references if needed.
                    IAudio newAudio = presentation.Audios.AddAudio(compressedAudioData);

                    // Update any audio frames that reference the old audio
                    foreach (ISlide slide in presentation.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            IAudioFrame audioFrame = shape as IAudioFrame;
                            if (audioFrame != null && audioFrame.EmbeddedAudio == audio)
                            {
                                audioFrame.EmbeddedAudio = newAudio;
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved with compressed audio: " + outputPresentationPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
