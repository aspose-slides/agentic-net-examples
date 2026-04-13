using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                Console.WriteLine("Enter slide number (1-based):");
                string slideNumStr = Console.ReadLine();
                int slideNumber;
                if (!int.TryParse(slideNumStr, out slideNumber) ||
                    slideNumber < 1 ||
                    slideNumber > presentation.Slides.Count)
                {
                    Console.WriteLine("Invalid slide number.");
                    return;
                }

                Console.WriteLine("Enter transition type (e.g., Fade, Zoom, Cut):");
                string transitionName = Console.ReadLine();

                // Parse the transition type enum
                Aspose.Slides.SlideShow.TransitionType transitionType;
                if (!Enum.TryParse<Aspose.Slides.SlideShow.TransitionType>(transitionName, true, out transitionType))
                {
                    Console.WriteLine("Invalid transition type.");
                    return;
                }

                // Apply the transition to the selected slide
                ISlideShowTransition slideTransition = presentation.Slides[slideNumber - 1].SlideShowTransition;
                slideTransition.Type = transitionType;

                // Use slide name as a simple tag to store the chosen transition
                presentation.Slides[slideNumber - 1].Name = "Transition:" + transitionType.ToString();

                // Save the presentation before exiting
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported file format
            Console.WriteLine("An error occurred: " + ex.Message);
            // Format not supported
        }
    }
}