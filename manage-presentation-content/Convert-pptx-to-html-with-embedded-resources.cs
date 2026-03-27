using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Create an animations generator for the presentation
                using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation))
                {
                    // Create a player to render animation frames at 30 FPS
                    using (PresentationPlayer player = new PresentationPlayer(animationsGenerator, 30))
                    {
                        // Subscribe to the FrameTick event with a method matching the delegate signature
                        player.FrameTick += new PresentationPlayer.FrameTickHandler(OnFrameTick);

                        // Run the generator to produce animation frames
                        animationsGenerator.Run(presentation.Slides);
                    }
                }

                // Save the (potentially modified) presentation in PPTX format
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
        }

        // Event handler that matches PresentationPlayer.FrameTickHandler delegate
        private static void OnFrameTick(PresentationPlayer sender, FrameTickEventArgs args)
        {
            // Save each generated frame as a PNG image
            string frameFile = $"frame_{sender.FrameIndex}.png";
            args.GetFrame().Save(frameFile, Aspose.Slides.ImageFormat.Png);
            Console.WriteLine("Saved frame: " + frameFile);
        }
    }
}