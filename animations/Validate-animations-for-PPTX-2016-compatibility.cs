using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace AnimationValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "validated_output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through each slide and its animations
                foreach (ISlide slide in presentation.Slides)
                {
                    IAnimationTimeLine timeline = slide.Timeline;
                    ISequence mainSequence = timeline.MainSequence;

                    foreach (IEffect effect in mainSequence)
                    {
                        // Example validation: output effect type (replace with real checks as needed)
                        Console.WriteLine("Slide " + slide.SlideNumber + " Effect Type: " + effect.Type);
                        // Additional compatibility checks can be added here
                    }
                }

                // Save the (potentially unchanged) presentation before exit
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
                Console.WriteLine("Validation completed. Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}