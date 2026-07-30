// -----------------------------------------------------------------------------
// Example: Replace audio frame thumbnail with waveform image using C#
//
// Description:
// Demonstrates how to replace an audio frame's thumbnail with a custom waveform
// image using C# and Aspose.Slides for .NET. The example loads a PPTX file,
// reads a PNG waveform image, adds the image to the presentation's image
// collection, iterates through all slides and shapes, replaces each audio
// frame's thumbnail, and saves the modified presentation. This pattern can be
// used to automate PPTX workflows, customize audio visuals, or integrate
// presentation processing into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Replace, AudioFrame, Thumbnail,
// Waveform Image, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replacement of audio frame thumbnails with custom waveform images.
// - Build C# utilities for PowerPoint presentation media customization.
// - Generate or transform PPTX files with enhanced audio visual cues in .NET.
// - Validate and test presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceAudioThumbnail
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";
            string waveformImagePath = "waveform.png";

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Verify that the waveform image exists
            if (!File.Exists(waveformImagePath))
            {
                Console.WriteLine($"Waveform image not found: {waveformImagePath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Load the waveform image bytes once
                    byte[] waveformBytes = File.ReadAllBytes(waveformImagePath);
                    // Add the waveform image to the presentation's image collection
                    IPPImage waveformImage = presentation.Images.AddImage(waveformBytes);

                    // Iterate through all slides
                    foreach (ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Check if the shape is an audio frame
                            IAudioFrame audioFrame = shape as IAudioFrame;
                            if (audioFrame != null)
                            {
                                // Replace the audio frame's thumbnail with the waveform image
                                audioFrame.PictureFormat.Picture.Image = waveformImage;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, network errors)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
