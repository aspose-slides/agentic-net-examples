// -----------------------------------------------------------------------------
// Example: Set audio frame PlayLoopMode false for video using C#
//
// Description:
// Demonstrates how to set the PlayLoopMode property of audio frames to false
// on slides that contain video frames using C# and Aspose.Slides for .NET.
// The example loads a presentation, checks each slide for video frames, and
// disables looping for any audio frames found on those slides. The modified
// presentation is then saved as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Audio, Frame, PlayLoopMode, False, Video, Presentation Processing, Office Automation
//
// Use Cases:
// - Disable audio looping on slides that contain video content.
// - Build C# utilities for fine‑tuning media playback in PowerPoint files.
// - Automate PPTX media settings in .NET applications.
// - Ensure correct audio behavior before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (args.Length > 0)
        {
            inputPath = args[0];
        }
        if (args.Length > 1)
        {
            outputPath = args[1];
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                foreach (ISlide slide in pres.Slides)
                {
                    bool hasVideo = false;
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IVideoFrame)
                        {
                            hasVideo = true;
                            break;
                        }
                    }

                    if (hasVideo)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            if (shape is IAudioFrame)
                            {
                                IAudioFrame audioFrame = (IAudioFrame)shape;
                                audioFrame.PlayLoopMode = false;
                            }
                        }
                    }
                }

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // format not supported
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // format not supported
        }
    }
}
