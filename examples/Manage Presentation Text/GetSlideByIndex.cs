using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input presentation file
        string inputPath = "input.pptx";
        // Path to the output presentation file
        string outputPath = "output.pptx";

        // Load the presentation from the specified file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Index of the slide to retrieve (zero‑based)
            int slideIndex = 0;

            // Get the slide reference using its index
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Example usage: display the retrieved slide index
            Console.WriteLine("Retrieved slide at index: " + slideIndex);

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}