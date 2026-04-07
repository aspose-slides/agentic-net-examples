using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToMp4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Directory to store generated frames
            string outputDir = "output_frames";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Ensure the output directory exists
                Directory.CreateDirectory(outputDir);

                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Create animations generator with desired frame size 1280x720
                    Size frameSize = new Size(1280, 720);
                    using (PresentationAnimationsGenerator generator = new PresentationAnimationsGenerator(frameSize))
                    {
                        // Create a player with 30 FPS
                        using (PresentationPlayer player = new PresentationPlayer(generator, 30))
                        {
                            int frameIndex = 0;
                            // Subscribe to frame tick event to save each frame as PNG
                            player.FrameTick += (sender, eventArgs) =>
                            {
                                string framePath = Path.Combine(outputDir, $"frame_{frameIndex.ToString("D5")}.png");
                                eventArgs.GetFrame().Save(framePath, Aspose.Slides.ImageFormat.Png);
                                frameIndex++;
                            };

                            // Run the generator for all slides
                            generator.Run(pres.Slides);
                        }
                    }

                    // Save the presentation (no modifications made) before exiting
                    pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Frames generated successfully in: " + outputDir);
                // Note: Combine the generated PNG frames into an MP4 video using an external encoder if required.
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}