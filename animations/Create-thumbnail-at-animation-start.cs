using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "AnimationFrames";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Directory.CreateDirectory(outputDir);

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                using (Aspose.Slides.Export.PresentationAnimationsGenerator animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation))
                {
                    animationsGenerator.NewAnimation += animationPlayer =>
                    {
                        // Capture the frame at the start of the animation (time position 0)
                        animationPlayer.SetTimePosition(0);
                        string framePath = Path.Combine(outputDir, $"animation_start_{DateTime.Now.Ticks}.png");
                        animationPlayer.GetFrame().Save(framePath, Aspose.Slides.ImageFormat.Png);
                    };

                    // Generate animation events for all slides
                    animationsGenerator.Run(presentation.Slides);
                }

                // Save the presentation before exiting (no modifications made)
                presentation.Save(inputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}