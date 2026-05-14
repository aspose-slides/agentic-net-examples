using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetFastTransitionForSummary
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides (or limit to the "Summary" section if needed)
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Set transition speed to Fast
                        slide.SlideShowTransition.Speed = Aspose.Slides.SlideShow.TransitionSpeed.Fast;
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}