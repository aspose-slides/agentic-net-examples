// -----------------------------------------------------------------------------
// Example: Mute audio frame on confidential slides using C#
//
// Description:
// Demonstrates how to add an audio file to a presentation, detect slides
// whose title contains the word "Confidential", insert an audio frame on those
// slides and set its volume to mute (0%). The example uses Aspose.Slides for
// .NET to load, modify, and save a PPTX file in a console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Mute, Audio, Frame, Confidential,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically mute audio on slides marked as confidential.
// - Build .NET tools that process PPTX files and adjust media settings.
// - Integrate audio muting logic into presentation generation pipelines.
// - Validate and enforce media policies before publishing PowerPoint decks.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string audioPath = "sampleaudio.wav";
        string outputPath = "output.pptx";

        // Verify input files exist
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Presentation file not found: " + inputPath);
            return;
        }
        if (!File.Exists(audioPath))
        {
            Console.WriteLine("Audio file not found: " + audioPath);
            return;
        }

        try
        {
            // Load presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Add audio to the presentation's audio collection
                IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes(audioPath));

                // Iterate through slides and mute audio frames on confidential slides
                foreach (ISlide slide in pres.Slides)
                {
                    // Placeholder logic to identify confidential slides
                    // For demonstration, assume slides with a title containing "Confidential"
                    bool isConfidential = false;
                    if (slide.Shapes.Count > 0)
                    {
                        // Attempt to find a title shape (placeholder logic)
                        foreach (IShape shape in slide.Shapes)
                        {
                            if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                            {
                                string text = autoShape.TextFrame.Text;
                                if (!string.IsNullOrEmpty(text) && text.IndexOf("Confidential", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    isConfidential = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (isConfidential)
                    {
                        // Add an audio frame and set its volume to mute (0%)
                        IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50f, 150f, 100f, 100f, audio);
                        audioFrame.VolumeValue = 0f; // Mute
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The provided file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URL issues)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
