using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input presentation path and output directory
        string inputPath = "input.pptx";
        string outputDir = "output_images";

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
            Presentation presentation = new Presentation(inputPath);

            // Save the presentation before exiting (as per requirement)
            presentation.Save("temp_save.pptx", SaveFormat.Pptx);

            // Iterate through each slide and export as JPEG with size 1024x768
            foreach (ISlide slide in presentation.Slides)
            {
                using (IImage image = slide.GetImage(new System.Drawing.Size(1024, 768)))
                {
                    string imagePath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}.jpg");
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Clean up
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}