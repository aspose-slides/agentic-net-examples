using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AnimationDebuggingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_debugged.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation with exception handling for unsupported formats
            Presentation presentation;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported or other loading error
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Use PresentationAnimationsGenerator to log animation steps
            using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation))
            {
                // Log each new animation's total duration
                animationsGenerator.NewAnimation += animationPlayer =>
                {
                    Console.WriteLine($"New animation generated. Total duration: {animationPlayer.Duration} ms");
                };

                // Create a player to iterate through frames and log each frame tick
                using (PresentationPlayer player = new PresentationPlayer(animationsGenerator, 30)) // 30 FPS
                {
                    player.FrameTick += (sender, eventArgs) =>
                    {
                        Console.WriteLine($"Frame {sender.FrameIndex} ticked.");
                        // Optionally, retrieve the frame image (not saved in this example)
                        // var frame = eventArgs.GetFrame();
                    };

                    // Run the animation generation for all slides
                    animationsGenerator.Run(presentation.Slides);
                }
            }

            // Save the presentation before exiting
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}