// -----------------------------------------------------------------------------
// Example: Extract audio from hyperlink and analyze its duration using C#
//
// Description:
// Demonstrates how to locate a shape with a hyperlink that contains an embedded
// audio (sound) object, extract the audio binary data, save it to a file, estimate
// its playback duration, and compare the estimated duration with the slide's
// transition duration. The example uses Aspose.Slides for .NET in a console
// application to automate PowerPoint presentation processing.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Hyperlink, Sound, Audio Extraction,
// Duration Estimation, SlideShowTransition, Presentation Automation
//
// Use Cases:
// - Extract embedded audio from a hyperlink in a PPTX file.
// - Estimate audio length and validate against slide timing.
// - Automate compliance checks for presentation audio and transitions.
// - Build .NET tools for processing and validating PowerPoint content.
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
        string outputAudioPath = "hyperlink_sound.mp3";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IShape shape = slide.Shapes[0];
            Aspose.Slides.IHyperlink link = shape.HyperlinkClick;

            if (link != null && link.Sound != null && link.Sound.BinaryData != null)
            {
                byte[] audioData = link.Sound.BinaryData;
                File.WriteAllBytes(outputAudioPath, audioData);

                // Simple duration estimate based on data size (placeholder logic)
                double audioDurationSeconds = audioData.Length / 1000.0;
                Console.WriteLine("Audio extracted. Approximate duration: " + audioDurationSeconds + " seconds.");

                // Compare with slide transition duration
                int slideDurationMs = slide.SlideShowTransition.Duration;
                double slideDurationSeconds = slideDurationMs / 1000.0;

                if (audioDurationSeconds <= slideDurationSeconds)
                {
                    Console.WriteLine("Audio duration complies with slide timing.");
                }
                else
                {
                    Console.WriteLine("Audio duration exceeds slide timing.");
                }
            }
            else
            {
                Console.WriteLine("No hyperlink sound found.");
            }

            // Save presentation before exit
            string outputPresPath = "output.pptx";
            pres.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("File format not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
