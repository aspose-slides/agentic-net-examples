using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string inputPath = "input.pptx";
        string outputDirectory = "output";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Calculate scaling factor for 300 DPI (default DPI is 72)
            float scaleFactor = 300f / 72f;

            // Export each slide to a high‑resolution JPEG image
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];
                using (Aspose.Slides.IImage image = slide.GetImage(scaleFactor, scaleFactor))
                {
                    string outputPath = Path.Combine(outputDirectory, $"Slide_{slide.SlideNumber}.jpg");
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Save the presentation before exiting (as required)
            presentation.Save(inputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or web services)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}