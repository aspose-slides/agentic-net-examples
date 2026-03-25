using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input presentation path
        string inputFile = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");

        // Check if the input file exists
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file not found: " + inputFile);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile);

        // Define high-resolution scaling factors
        float scaleX = 3f;
        float scaleY = 3f;

        // Render each slide as a high-resolution PNG image
        for (int index = 0; index < presentation.Slides.Count; index++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[index];
            Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY);
            string outputImage = Path.Combine(Directory.GetCurrentDirectory(), $"slide_{index}.png");
            image.Save(outputImage, Aspose.Slides.ImageFormat.Png);
        }

        // Save the (unchanged) presentation before exiting
        string outputPresentation = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
        presentation.Save(outputPresentation, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}