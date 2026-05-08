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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Initialize the animations generator with the presentation's slide size
                using (Aspose.Slides.Export.PresentationAnimationsGenerator animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation))
                {
                    // Create a player to process animation frames at 30 FPS
                    using (Aspose.Slides.Export.PresentationPlayer player = new Aspose.Slides.Export.PresentationPlayer(animationsGenerator, 30))
                    {
                        // Optional: handle each generated frame (e.g., save as images)
                        player.FrameTick += (sender, args) =>
                        {
                            // Example: save each frame as a PNG image (commented out to avoid extra I/O)
                            // args.GetFrame().Save($"frame_{sender.FrameIndex}.png", Aspose.Slides.Export.SaveFormat.Png);
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
                    Aspose.Slides.Export.SaveFormat mp4Format = (Aspose.Slides.Export.SaveFormat)Enum.Parse(
                        typeof(Aspose.Slides.Export.SaveFormat), "Mp4");

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