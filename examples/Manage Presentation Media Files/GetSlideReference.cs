using System;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        System.String inputPath = "input.pptx";
        // Output PPTX file path
        System.String outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access the first slide by index
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Example operation: display slide number
        Console.WriteLine("Slide number: " + slide.SlideNumber);

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}