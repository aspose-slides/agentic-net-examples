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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Set zoom to fit‑to‑width (auto scaling)
            presentation.ViewProperties.SlideViewProperties.VariableScale = true;
            // Optionally set an explicit scale value (percentage)
            presentation.ViewProperties.SlideViewProperties.Scale = 100;

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Verify visual layout by outputting the current scale
            Console.WriteLine("Zoom scale set to: " + presentation.ViewProperties.SlideViewProperties.Scale);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors (e.g., external URL issues)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}