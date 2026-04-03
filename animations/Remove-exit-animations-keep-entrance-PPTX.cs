using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace RemoveExitAnimations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Iterate through each slide
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    // Get the main animation sequence of the slide
                    ISequence seq = pres.Slides[i].Timeline.MainSequence;

                    // Iterate through effects in reverse to allow removal if needed
                    for (int j = seq.Count - 1; j >= 0; j--)
                    {
                        IEffect effect = seq[j];

                        // Identify exit animations by their AfterAnimationType
                        // (Assuming HideAfterAnimation indicates an exit animation)
                        if (effect.AfterAnimationType == AfterAnimationType.HideAfterAnimation)
                        {
                            // Remove the exit animation by deleting it from the sequence
                            seq.RemoveAt(j);
                        }
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}