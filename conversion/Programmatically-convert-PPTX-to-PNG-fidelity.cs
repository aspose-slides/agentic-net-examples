using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source presentation
            string inputPath = "input.pptx";

            // Directory to store the generated PNG images
            string outputDir = "output_images";
            Directory.CreateDirectory(outputDir);

            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    // Get the current slide
                    ISlide slide = pres.Slides[i];

                    // Render the slide to an image (default 20% size)
                    IImage slideImage = slide.GetImage();

                    // Build the output file name
                    string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.png");

                    // Save the image as PNG using Aspose.Slides.ImageFormat
                    slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }

                // Save the presentation (required by lifecycle rule)
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Simple error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}