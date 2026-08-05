// -----------------------------------------------------------------------------
// Example: Create chart animation video and save mp4 using C#
//
// Description:
// Demonstrates how to generate animation frames for a chart in a PowerPoint
// presentation using Aspose.Slides for .NET, capture each frame as PNG images,
// and outlines the steps required to assemble these frames into an MP4 video
// (e.g., via a third‑party encoder). The example also saves the processed
// presentation. This pattern can be used to automate chart animation extraction
// and video creation workflows in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Animation, Video, MP4, 
// Frame Extraction, PNG, Presentation Processing, Office Automation
//
// Use Cases:
// - Extract chart animation frames from a PPTX and save as image sequence.
// - Build tools to convert PowerPoint chart animations into video files.
// - Integrate Aspose.Slides animation processing into .NET automation pipelines.
// - Prepare assets for further video encoding with external tools like FFmpeg.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ChartAnimationVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect two arguments: input presentation path and output folder path
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ChartAnimationVideo <input.pptx> <output_folder>");
                return;
            }

            string inputPath = args[0];
            string outputFolder = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create output folder if it does not exist
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Initialize the animations generator with the presentation's slide size
                    using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation))
                    {
                        // Create a player with desired frames per second (e.g., 30 FPS)
                        using (PresentationPlayer player = new PresentationPlayer(animationsGenerator, 30))
                        {
                            // Subscribe to the FrameTick event to capture each frame as an image
                            player.FrameTick += (sender, eventArgs) =>
                            {
                                string frameFile = Path.Combine(outputFolder, $"frame_{sender.FrameIndex}.png");
                                eventArgs.GetFrame().Save(frameFile, Aspose.Slides.ImageFormat.Png);
                            };

                            // Run the animation generation for all slides
                            animationsGenerator.Run(presentation.Slides);
                        }
                    }

                    // NOTE: Aspose.Slides does not support saving animations directly as MP4.
                    // The SaveFormat enumeration does not contain an Mp4 value.
                    // To create an MP4 video, you would need to encode the generated PNG frames
                    // using a third‑party video encoding library (e.g., FFmpeg).

                    // Save the presentation (required before exiting)
                    string savedPresentationPath = Path.Combine(outputFolder, "ProcessedPresentation.pptx");
                    presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException notSupEx)
            {
                // Handle cases where a requested format is not supported
                Console.WriteLine($"Operation not supported: {notSupEx.Message}");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., file I/O errors)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
