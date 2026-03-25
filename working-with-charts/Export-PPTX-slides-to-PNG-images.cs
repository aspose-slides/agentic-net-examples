using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input presentation file
        string inputPath = "input.pptx";

        // Output file name pattern (e.g., slide_0.png, slide_1.png, ...)
        string outputPattern = "slide_{0}.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Error: Input file not found - " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Iterate through each slide and export it as a PNG image
        for (int index = 0; index < pres.Slides.Count; index++)
        {
            Aspose.Slides.ISlide slide = pres.Slides[index];
            using (Aspose.Slides.IImage image = slide.GetImage())
            {
                string outputPath = string.Format(outputPattern, index);
                image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
            }
        }

        // Clean up resources
        pres.Dispose();
    }
}