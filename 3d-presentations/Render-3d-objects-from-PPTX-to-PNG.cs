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
            string outputDirectory = "output_images";
            Directory.CreateDirectory(outputDirectory);

            using (Presentation presentation = new Presentation(inputPath))
            {
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    float scaleX = 2f;
                    float scaleY = 2f;

                    using (IImage image = slide.GetImage(scaleX, scaleY))
                    {
                        string outputPath = Path.Combine(outputDirectory, $"slide_{index + 1}.png");
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the (unchanged) presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (PptxReadException ex)
        {
            Console.WriteLine("Error reading PPTX file: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred: " + ex.Message);
        }
    }
}