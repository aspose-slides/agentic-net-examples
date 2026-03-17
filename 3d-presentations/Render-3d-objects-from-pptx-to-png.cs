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
            string inputPath = "input.pptx";
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);

            using (Presentation presentation = new Presentation(inputPath))
            {
                // Rendering options to preserve visual fidelity
                RenderingOptions renderingOptions = new RenderingOptions();

                // Get raster images for all slides
                IImage[] slideImages = presentation.GetImages(renderingOptions);
                for (int index = 0; index < slideImages.Length; index++)
                {
                    IImage slideImage = slideImages[index];
                    string outputPath = Path.Combine(outputDirectory, $"slide_{index + 1}.png");
                    slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    slideImage.Dispose();
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}