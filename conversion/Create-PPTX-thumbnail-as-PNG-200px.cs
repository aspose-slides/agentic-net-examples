using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output folder for PNG thumbnails
        string outputFolder = "output";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure the output directory exists
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Save the presentation before exiting (as required)
            string tempSavePath = Path.Combine(outputFolder, "temp_saved.pptx");
            pres.Save(tempSavePath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Determine scaling factor to keep the maximum dimension at 200 pixels
            float maxDimension = 200f;
            float slideWidth = pres.SlideSize.Size.Width;
            float slideHeight = pres.SlideSize.Size.Height;
            float scale = maxDimension / Math.Max(slideWidth, slideHeight);
            if (scale > 1f) scale = 1f; // Avoid upscaling

            // Generate PNG thumbnail for each slide
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[i];
                Aspose.Slides.IImage image = slide.GetImage(scale, scale);
                string outputPng = Path.Combine(outputFolder, $"slide_{i + 1}.png");
                image.Save(outputPng, Aspose.Slides.ImageFormat.Png);
                image.Dispose();
            }

            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., web service errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}