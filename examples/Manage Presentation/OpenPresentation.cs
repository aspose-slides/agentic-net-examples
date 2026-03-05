using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file
        string sourcePath = "Sample.pptx";
        // Path to the output presentation file
        string outputPath = "OutputPresentation.pptx";

        // Open the presentation using Aspose.Slides
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Display basic information about the presentation
            Console.WriteLine("Number of slides: " + presentation.Slides.Count);
            Console.WriteLine("First slide number: " + presentation.FirstSlideNumber);

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}