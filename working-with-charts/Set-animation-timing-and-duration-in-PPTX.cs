using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Set precise transition durations (in milliseconds) for the first three slides
        if (presentation.Slides.Count > 0)
        {
            presentation.Slides[0].SlideShowTransition.Duration = 2000; // 2 seconds
            presentation.Slides[0].SlideShowTransition.AdvanceOnClick = false;
            presentation.Slides[0].SlideShowTransition.AdvanceAfterTime = 2000;
        }
        if (presentation.Slides.Count > 1)
        {
            presentation.Slides[1].SlideShowTransition.Duration = 3500; // 3.5 seconds
            presentation.Slides[1].SlideShowTransition.AdvanceOnClick = false;
            presentation.Slides[1].SlideShowTransition.AdvanceAfterTime = 3500;
        }
        if (presentation.Slides.Count > 2)
        {
            presentation.Slides[2].SlideShowTransition.Duration = 5000; // 5 seconds
            presentation.Slides[2].SlideShowTransition.AdvanceOnClick = false;
            presentation.Slides[2].SlideShowTransition.AdvanceAfterTime = 5000;
        }

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}