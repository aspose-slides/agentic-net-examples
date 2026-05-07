using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];

                    // Export each slide as PNG with alpha channel preserved
                    using (IImage image = slide.GetImage(1f, 1f))
                    {
                        string outputPath = $"slide_{i}.png";
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the presentation (required before exit)
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: The provided file format is not supported by Aspose.Slides.
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors, network issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}