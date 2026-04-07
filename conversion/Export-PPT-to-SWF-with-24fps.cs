using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionExample
{
    class Program
    {
        static void Main()
        {
            var inputPath = "input.pptx";
            var outputPath = "output.swf";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (var presentation = new Presentation(inputPath))
                {
                    // Configure SWF options
                    var swfOptions = new SwfOptions();
                    swfOptions.ViewerIncluded = true;

                    // Set up animation player with 24 FPS (required for frame rate)
                    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
                    using (var player = new PresentationPlayer(animationsGenerator, 24))
                    {
                        // Run the generator to process animations (no frame handling needed for SWF)
                        animationsGenerator.Run(presentation.Slides);
                    }

                    // Save presentation as SWF
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}