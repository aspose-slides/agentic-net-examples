using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "output";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Export each slide to JPEG with quality parameter (progressive encoding)
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    IImage image = slide.GetImage();
                    string outputPath = Path.Combine(outputDir, "slide_" + (i + 1) + ".jpg");
                    // Quality value (0-100) influences JPEG compression; higher values retain more detail.
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg, 80);
                }

                // Save the presentation (no modifications) before exiting as per lifecycle rule
                string tempSavePath = Path.Combine(outputDir, "temp_saved.pptx");
                pres.Save(tempSavePath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other possible exceptions (e.g., I/O errors, network issues)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}