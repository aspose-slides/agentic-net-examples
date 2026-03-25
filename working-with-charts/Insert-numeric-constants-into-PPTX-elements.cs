using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputFile = "input.pptx";
        string outputFile = "output.pptx";

        // If a command‑line argument is provided, use it as the input file
        if (args.Length > 0)
        {
            inputFile = args[0];
        }

        // Verify that the input file exists
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file not found: " + inputFile);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

        // Predefined numeric constant to apply to all slides
        int constantSlideNumber = 5;

        // Set the first slide number consistently across the presentation
        presentation.FirstSlideNumber = constantSlideNumber;

        // Save the modified presentation
        presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}