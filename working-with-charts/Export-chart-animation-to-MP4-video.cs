// -----------------------------------------------------------------------------
// Example: Export chart animation to MP4 video using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation that contains chart
// animations, generate the animation frames with Aspose.Slides for .NET, and
// attempt to export the resulting animation as an MP4 video file. The sample
// shows the use of PresentationAnimationsGenerator, PresentationPlayer, and
// runtime resolution of the MP4 SaveFormat, handling cases where the format
// is not supported by the current library version.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Chart, Animation, MP4, Video,
// PresentationExport, PresentationProcessing, Office Automation
//
// Use Cases:
// - Convert chart animation sequences in PPTX files to MP4 video.
// - Build automated tools that process slide animations and generate video output.
// - Validate MP4 export capability and gracefully handle unsupported formats.
// - Integrate slide animation rendering into .NET applications.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ChartAnimationToMp4
{
    class Program
    {
        static void Main()
        {
            // Path to the source presentation containing chart animations
            string sourcePath = "ChartAnimation.pptx";

            // Verify that the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source presentation not found: " + sourcePath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Initialize the animations generator with the presentation's slide size
                using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation))
                {
                    // Create a player to process animation frames at 30 FPS
                    using (PresentationPlayer player = new PresentationPlayer(animationsGenerator, 30))
                    {
                        // Optional: handle each generated frame (e.g., save as images)
                        player.FrameTick += (sender, args) =>
                        {
                            // Example: save each frame as a PNG image (commented out to avoid extra I/O)
                            // args.GetFrame().Save($"frame_{sender.FrameIndex}.png", SaveFormat.Png);
                        };

                        // Run the animation generation for all slides
                        animationsGenerator.Run(presentation.Slides);
                    }
                }

                // Attempt to save the presentation as an MP4 video
                try
                {
                    // MP4 may not be a supported SaveFormat in the current library version.
                    // Use Enum.Parse to obtain the enum value by name at runtime.
                    SaveFormat mp4Format = (SaveFormat)Enum.Parse(typeof(SaveFormat), "Mp4");
                    presentation.Save("ChartAnimation.mp4", mp4Format);
                }
                catch (NotSupportedException)
                {
                    // MP4 format is not supported by this version of Aspose.Slides
                    Console.WriteLine("MP4 format not supported. Unable to export video.");
                }
                catch (ArgumentException)
                {
                    // The enum value "Mp4" does not exist; handle gracefully
                    Console.WriteLine("MP4 format is unavailable in the SaveFormat enumeration.");
                }
            }
        }
    }
}
