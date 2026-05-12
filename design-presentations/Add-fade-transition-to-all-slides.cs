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

        // Load the presentation with exception handling for unsupported formats
        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Error loading presentation: " + ex.Message);
            return;
        }

        // Apply fade transition to every slide
        for (int i = 0; i < pres.Slides.Count; i++)
        {
            pres.Slides[i].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
            // Set transition duration to 1 second (1000 ms) for smoother visual flow
            pres.Slides[i].SlideShowTransition.Duration = 1000;
        }

        // Save the modified presentation before exiting
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}