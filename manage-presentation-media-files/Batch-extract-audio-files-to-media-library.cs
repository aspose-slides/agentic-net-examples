// -----------------------------------------------------------------------------
// Example: Batch extract audio files to media library using C#
//
// Description:
// Demonstrates how to batch extract embedded audio files from PowerPoint
// presentations to a media library using C# and Aspose.Slides for .NET. The
// example processes all presentation files in a specified input folder,
// extracts each audio stream to separate files in an output folder, and
// saves the original presentations back in PPTX format. This pattern can be
// used to automate PPTX workflows, archive media assets, or integrate
// presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Batch, Extract, Audio, Files,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate batch extraction of audio files from multiple presentations.
// - Build C# tools for PowerPoint media asset management.
// - Generate or transform PPTX files in .NET applications while preserving media.
// - Validate and archive presentation audio content before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchAudioExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input folder containing presentations
            string inputFolder = args.Length > 0 ? args[0] : "InputPresentations";
            // Output folder for extracted audio files
            string outputFolder = args.Length > 1 ? args[1] : "ExtractedAudio";

            // Verify input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }

            // Ensure output folder exists
            Directory.CreateDirectory(outputFolder);

            // Process each file in the input folder
            foreach (string filePath in Directory.GetFiles(inputFolder))
            {
                try
                {
                    // Load presentation (supports ppt, pptx, odp, etc.)
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath);

                    // Extract all embedded audio files
                    Aspose.Slides.IAudioCollection audioCollection = pres.Audios;
                    for (int i = 0; i < audioCollection.Count; i++)
                    {
                        Aspose.Slides.IAudio audio = audioCollection[i];
                        if (audio != null && audio.BinaryData != null)
                        {
                            string audioFileName = Path.GetFileNameWithoutExtension(filePath) + $"_audio_{i}.bin";
                            string outPath = Path.Combine(outputFolder, audioFileName);
                            File.WriteAllBytes(outPath, audio.BinaryData);
                        }
                    }

                    // Save presentation before exiting (no modifications made)
                    pres.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    pres.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported – comment as required
                    Console.WriteLine("File format not supported: " + filePath);
                }
                catch (Exception ex)
                {
                    // General error handling
                    Console.WriteLine("Error processing file '" + filePath + "': " + ex.Message);
                }
            }
        }
    }
}
