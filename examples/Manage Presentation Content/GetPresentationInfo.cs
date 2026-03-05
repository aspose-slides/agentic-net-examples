using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string inputPath = "sample.pptx";

        // Obtain presentation information using PresentationFactory
        Aspose.Slides.IPresentationFactory factory = Aspose.Slides.PresentationFactory.Instance;
        Aspose.Slides.IPresentationInfo info = factory.GetPresentationInfo(inputPath);

        // Display the detected load format
        Console.WriteLine("Load format: " + info.LoadFormat);

        // Load the presentation for further processing
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Save the presentation before exiting (can be the same or a new file)
        string outputPath = "output.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}