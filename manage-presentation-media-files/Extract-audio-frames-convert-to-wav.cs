// -----------------------------------------------------------------------------
// Example: Extract audio frames convert to wav using C#
//
// Description:
// Demonstrates how to extract embedded audio frames from a PowerPoint presentation
// and convert them to WAV files using C# and Aspose.Slides for .NET. The example
// loads a PPTX file, iterates through its slides and shapes, extracts audio data
// from IAudioFrame objects, and writes the binary audio content to separate WAV
// files in an output directory. This pattern can be used to automate media
// extraction tasks in presentation processing workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Audio, Frames, Convert,
// WAV, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of embedded audio from PowerPoint files.
// - Build tools that convert presentation audio to standard WAV format.
// - Integrate audio media handling into .NET applications that process PPTX.
// - Validate and archive audio assets from presentations before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioExtractionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for extracted WAV files
            string outputDirectory = "ExtractedAudio";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                // Handle other loading exceptions
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Iterate through slides and extract embedded audio frames
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];
                    if (shape is IAudioFrame)
                    {
                        IAudioFrame audioFrame = (IAudioFrame)shape;
                        IAudio embeddedAudio = audioFrame.EmbeddedAudio;
                        if (embeddedAudio != null && embeddedAudio.BinaryData != null)
                        {
                            string outputFilePath = Path.Combine(
                                outputDirectory,
                                $"slide{slideIndex + 1}_shape{shapeIndex + 1}.wav");
                            File.WriteAllBytes(outputFilePath, embeddedAudio.BinaryData);
                        }
                    }
                }
            }

            // Save presentation before exiting (no changes made, but required by lifecycle rule)
            try
            {
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                // Dispose presentation resources
                presentation.Dispose();
            }
        }
    }
}
