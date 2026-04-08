using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to a local file used to simulate receiving data over a network stream
        string sourcePath = "input.pptx";

        // Verify that the source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file not found.");
            return;
        }

        // Read the presentation file into a byte array (simulating network data)
        byte[] presentationData = File.ReadAllBytes(sourcePath);

        // Load the presentation from the byte array
        IPresentation presentation;
        try
        {
            presentation = PresentationFactory.Instance.ReadPresentation(presentationData);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("Presentation format not supported.");
            return;
        }

        // Iterate through each slide and render it to an image
        for (int index = 0; index < presentation.Slides.Count; index++)
        {
            ISlide slide = presentation.Slides[index];
            // GetImage returns a thumbnail (20% of real size) by default
            IImage slideImage = slide.GetImage();
            string outputImagePath = $"slide_{index + 1}.jpg";
            slideImage.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}