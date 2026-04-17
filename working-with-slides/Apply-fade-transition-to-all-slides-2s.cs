using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            var presentation = new Presentation(inputPath);

            // Apply Fade transition with a 2‑second delay to each slide
            for (var i = 0; i < presentation.Slides.Count; i++)
            {
                presentation.Slides[i].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Fade;
                presentation.Slides[i].SlideShowTransition.AdvanceOnClick = true;
                presentation.Slides[i].SlideShowTransition.AdvanceAfterTime = 2000; // 2 seconds
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}