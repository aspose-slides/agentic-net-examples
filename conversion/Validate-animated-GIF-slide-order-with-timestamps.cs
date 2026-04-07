using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace GifConversionValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output paths
            string inputPath = "input.pptx";
            string outputGifPath = "output.gif";
            string framesOutputDir = "frames";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(framesOutputDir);

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure GIF options
                GifOptions gifOptions = new GifOptions();
                gifOptions.FrameSize = new Size(960, 720);
                gifOptions.DefaultDelay = 2000; // 2 seconds per slide
                gifOptions.TransitionFps = 35;

                // Save as animated GIF
                presentation.Save(outputGifPath, SaveFormat.Gif, gifOptions);

                // Generate frames to validate slide order
                List<int> frameIndices = new List<int>();
                using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation))
                {
                    // Subscribe to new animation event to handle each animation sequence
                    animationsGenerator.NewAnimation += animationPlayer =>
                    {
                        // Use a player with the same FPS as GIF transition FPS
                        using (PresentationPlayer player = new PresentationPlayer(animationsGenerator, gifOptions.TransitionFps))
                        {
                            player.FrameTick += (sender, eventArgs) =>
                            {
                                // Save each frame (optional)
                                string framePath = Path.Combine(framesOutputDir, $"frame_{sender.FrameIndex}.png");
                                eventArgs.GetFrame().Save(framePath);

                                // Record frame index to verify order
                                frameIndices.Add(sender.FrameIndex);
                            };

                            // Run the animation for all slides
                            animationsGenerator.Run(presentation.Slides);
                        }
                    };

                    // Start animation generation
                    animationsGenerator.Run(presentation.Slides);
                }

                // Simple validation: ensure frame indices are in ascending order
                bool orderPreserved = true;
                for (int i = 1; i < frameIndices.Count; i++)
                {
                    if (frameIndices[i] < frameIndices[i - 1])
                    {
                        orderPreserved = false;
                        break;
                    }
                }

                Console.WriteLine(orderPreserved
                    ? "Validation passed: Frame order matches slide order."
                    : "Validation failed: Frame order does not match slide order.");

                // Save presentation before exit (as per requirement)
                presentation.Save("validated_output.pptx", SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}