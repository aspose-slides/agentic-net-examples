using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        string inputPath = "input.pptx";
        // Output directory for JPG files
        string outputDir = "output";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    // Generate a full‑scale image of the slide (default dimensions)
                    IImage image = slide.GetImage(1f, 1f);
                    // Build the output file name
                    string outputPath = Path.Combine(outputDir, $"Slide_{i + 1}.jpg");
                    // Save the image as high‑quality JPEG
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save the presentation (required by lifecycle rule)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}