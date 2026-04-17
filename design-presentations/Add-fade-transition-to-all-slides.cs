using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FadeTransitionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation. Possible unsupported format.");
                Console.WriteLine("Error: " + ex.Message);
                return;
            }

            // Apply Fade transition to each slide with a duration of 1 second (1000 ms)
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                presentation.Slides[i].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                presentation.Slides[i].SlideShowTransition.Duration = 1000;
                presentation.Slides[i].SlideShowTransition.AdvanceOnClick = true;
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}