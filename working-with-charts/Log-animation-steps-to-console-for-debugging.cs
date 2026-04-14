using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesAnimationLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"File not found: {inputPath}");
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(pres))
                    {
                        // Log each new animation's total duration
                        animationsGenerator.NewAnimation += (IPresentationAnimationPlayer animationPlayer) =>
                        {
                            Console.WriteLine($"New animation generated. Total duration: {animationPlayer.Duration} ms");
                        };

                        // Create a player with desired FPS
                        using (PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33))
                        {
                            // Log each frame tick (step) of the animation
                            player.FrameTick += new PresentationPlayer.FrameTickHandler((PresentationPlayer sender, FrameTickEventArgs eventArgs) =>
                            {
                                Console.WriteLine($"Frame {sender.FrameIndex} generated.");
                                // Optionally, save each frame as an image for further inspection
                                // string framePath = Path.Combine("Frames", $"frame_{sender.FrameIndex}.png");
                                // eventArgs.GetFrame().Save(framePath, Aspose.Slides.Export.ImageFormat.Png);
                            });

                            // Run the animation generation for all slides
                            animationsGenerator.Run(pres.Slides);
                        }

                        // Save the presentation after processing
                        string outputPath = "output.pptx";
                        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                        Console.WriteLine($"Presentation saved to {outputPath}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Format not supported comment:
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}