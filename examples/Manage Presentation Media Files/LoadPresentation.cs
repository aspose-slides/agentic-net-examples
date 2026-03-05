using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file that contains images
        string inputPath = "input.pptx";

        // Path to save the presentation after loading
        string outputPath = "output.pptx";

        // Load the presentation using the fully-qualified Presentation class
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Example operation: output the number of images in the presentation
        int imageCount = presentation.Images.Count;
        Console.WriteLine("Number of images in the presentation: " + imageCount);

        // Save the presentation before exiting
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}