using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputVideoPath = "output.mp4";
        string framesDirectory = "frames_30fps";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Set slide size to 1280x720 points without scaling content
                pres.SlideSize.SetSize(1280f, 720f, SlideSizeScaleType.DoNotScale);

                // Ensure output directory for frames exists
                Directory.CreateDirectory(framesDirectory);

                // Initialize animations generator with desired frame size
                using (PresentationAnimationsGenerator generator = new PresentationAnimationsGenerator(new Size(1280, 720)))
                {
                    // Create player with 30 FPS
                    using (PresentationPlayer player = new PresentationPlayer(generator, 30.0))
                    {
                        int frameCounter = 0;
                        player.FrameTick += (sender, args) =>
                        {
                            string framePath = Path.Combine(framesDirectory, $"frame_{frameCounter++.ToString("D5")}.png");
                            args.GetFrame().Save(framePath, Aspose.Slides.ImageFormat.Png);
                        };

                        // Generate animation frames for all slides
                        generator.Run(pres.Slides);
                    }
                }

                // NOTE: Aspose.Slides does not provide direct MP4 export.
                // The generated PNG frames can be combined into an MP4 video using an external encoder.
                // If MP4 export were supported, the following call would be used:
                // pres.Save(outputVideoPath, SaveFormat.Mp4);
                // Since the format is not supported, we handle it gracefully.

                // Save the (potentially modified) presentation before exiting
                pres.Save("saved_output.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("MP4 format is not supported by Aspose.Slides.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}