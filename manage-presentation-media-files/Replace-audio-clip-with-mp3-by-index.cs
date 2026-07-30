// -----------------------------------------------------------------------------
// Example: Replace audio clip with mp3 by index using C#
//
// Description:
// Demonstrates how to replace an existing audio clip on a specific slide
// with a new MP3 file by using its slide index. The example loads a PPTX,
// locates the first audio frame on the given slide, adds the MP3 to the
// presentation's audio collection, substitutes the embedded audio, and
// saves the modified presentation. It uses Aspose.Slides for .NET and can
// be run as a standalone console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace Audio, MP3, Slide Index,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replacement of audio clips in PowerPoint presentations.
// - Build command‑line tools for updating media assets in PPTX files.
// - Integrate audio update functionality into .NET applications.
// - Validate and test presentation media workflows before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceAudioExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expected arguments: input presentation path, slide index (0‑based), new audio MP3 path, output presentation path
            if (args.Length != 4)
            {
                Console.WriteLine("Usage: ReplaceAudioExample <input.pptx> <slideIndex> <newAudio.mp3> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string slideIndexArg = args[1];
            string newAudioPath = args[2];
            string outputPath = args[3];

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist: " + inputPath);
                return;
            }

            if (!File.Exists(newAudioPath))
            {
                Console.WriteLine("New audio file does not exist: " + newAudioPath);
                return;
            }

            int slideIndex;
            if (!Int32.TryParse(slideIndexArg, out slideIndex))
            {
                Console.WriteLine("Invalid slide index: " + slideIndexArg);
                return;
            }

            Presentation pres = null;
            try
            {
                // Load the presentation
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation. Possible unsupported format. Details: " + ex.Message);
                return;
            }

            // Validate slide index range
            if (slideIndex < 0 || slideIndex >= pres.Slides.Count)
            {
                Console.WriteLine("Slide index out of range.");
                pres.Dispose();
                return;
            }

            // Get the target slide
            ISlide slide = pres.Slides[slideIndex];

            // Find the first audio frame on the slide
            IAudioFrame audioFrame = null;
            foreach (IShape shape in slide.Shapes)
            {
                audioFrame = shape as IAudioFrame;
                if (audioFrame != null)
                {
                    break;
                }
            }

            if (audioFrame == null)
            {
                Console.WriteLine("No audio frame found on the specified slide.");
                pres.Dispose();
                return;
            }

            // Add the new high‑quality MP3 audio to the presentation's audio collection
            IAudio newAudio = null;
            try
            {
                byte[] audioBytes = File.ReadAllBytes(newAudioPath);
                newAudio = pres.Audios.AddAudio(audioBytes);
            }
            catch (Exception ex)
            {
                // Handle errors reading the audio file or unsupported audio format
                Console.WriteLine("Failed to add new audio. Details: " + ex.Message);
                pres.Dispose();
                return;
            }

            // Replace the embedded audio of the existing audio frame
            audioFrame.EmbeddedAudio = newAudio;

            // Save the updated presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation. Details: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                pres.Dispose();
            }
        }
    }
}
