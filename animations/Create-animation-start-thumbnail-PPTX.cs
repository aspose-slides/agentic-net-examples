using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailFromAnimationStart
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "input.pptx";
            var outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            try
            {
                var presentation = new Aspose.Slides.Presentation(inputPath);
                Directory.CreateDirectory(outputDir);

                var animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation);
                animationsGenerator.NewAnimation += animationPlayer =>
                {
                    // Capture the first frame of the animation (start)
                    animationPlayer.SetTimePosition(0);
                    var filePath = Path.Combine(outputDir, $"slide_{animationPlayer.Duration}_start.png");
                    animationPlayer.GetFrame().Save(filePath);
                };

                animationsGenerator.Run(presentation.Slides);

                // Save the presentation before exiting
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
                animationsGenerator.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}