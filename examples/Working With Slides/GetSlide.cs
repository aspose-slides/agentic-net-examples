using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file
        string inputPath = "input.pptx";
        // Path where the modified presentation will be saved
        string outputPath = "output.pptx";

        // Load the presentation from the specified file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Index of the slide to retrieve (zero‑based)
            int slideIndex = 0;

            // Retrieve the slide using the Slides collection indexer
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Example usage: output the slide index to the console
            Console.WriteLine("Retrieved slide at index: " + slideIndex);

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}