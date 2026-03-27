using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomGraphicsSubsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input PPTX file path
            string inputPath;
            if (args.Length > 0)
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "input.pptx";
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Determine output directory
            string outputDir;
            if (args.Length > 1)
            {
                outputDir = args[1];
            }
            else
            {
                outputDir = "output";
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Export each slide to an SVG file
            string svgPathPattern = Path.Combine(outputDir, "slide_{0}.svg");
            for (int index = 0; index < pres.Slides.Count; index++)
            {
                ISlide slide = pres.Slides[index];
                using (FileStream svgStream = new FileStream(string.Format(svgPathPattern, index + 1), FileMode.Create, FileAccess.Write))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }

            // Generate animation frames at 30 FPS
            using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(pres))
            {
                using (PresentationPlayer player = new PresentationPlayer(animationsGenerator, 30))
                {
                    string frameDir = Path.Combine(outputDir, "frames_30fps");
                    Directory.CreateDirectory(frameDir);

                    player.FrameTick += (sender, eventArgs) =>
                    {
                        string framePath = Path.Combine(frameDir, $"frame_{sender.FrameIndex}.png");
                        eventArgs.GetFrame().Save(framePath, Aspose.Slides.ImageFormat.Png);
                    };

                    animationsGenerator.Run(pres.Slides);
                }
            }

            // Save the (potentially modified) presentation
            string savedPath = Path.Combine(outputDir, "processed.pptx");
            pres.Save(savedPath, SaveFormat.Pptx);

            // Clean up resources
            pres.Dispose();

            Console.WriteLine("Processing completed. Output saved to: " + outputDir);
        }
    }
}