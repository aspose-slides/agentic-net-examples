// -----------------------------------------------------------------------------
// Example: Validate audio frame thumbnail and report missing using C#
//
// Description:
// Demonstrates how to validate audio frame thumbnails and report any missing 
// thumbnails using C# and Aspose.Slides for .NET. The example loads a PPTX 
// file, iterates through all slides and shapes, checks each audio frame for an 
// assigned thumbnail image, reports slides with missing thumbnails, and saves 
// the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Audio, Frame, 
// Thumbnail, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validation of audio frame thumbnails in PowerPoint presentations.
// - Build C# tools for detecting missing media assets before publishing.
// - Integrate presentation quality checks into .NET applications.
// - Generate reports on media completeness in PPTX files.
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
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                bool anyMissing = false;

                // Iterate through all slides
                foreach (ISlide slide in pres.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        IAudioFrame audioFrame = shape as IAudioFrame;
                        if (audioFrame != null)
                        {
                            // Check if the audio frame has a thumbnail image assigned
                            IPPImage thumbnail = audioFrame.PictureFormat.Picture.Image;
                            if (thumbnail == null)
                            {
                                anyMissing = true;
                                Console.WriteLine("Audio frame on slide " + slide.SlideNumber + " is missing a thumbnail.");
                            }
                        }
                    }
                }

                if (!anyMissing)
                {
                    Console.WriteLine("All audio frames have thumbnails.");
                }

                // Save the presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
