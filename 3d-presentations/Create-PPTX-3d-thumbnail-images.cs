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
        // Output directory for thumbnails
        string outputDir = "Thumbnails";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Desired thumbnail dimensions
            int desiredX = 200;
            int desiredY = 200;

            // Calculate scaling factors based on slide size
            float scaleX = (float)(1.0 / presentation.SlideSize.Size.Width) * desiredX;
            float scaleY = (float)(1.0 / presentation.SlideSize.Size.Height) * desiredY;

            // Iterate through each slide (assuming all are 3D slides)
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                // Generate thumbnail with custom scaling
                Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY);
                string outputPath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}.jpg");
                image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                image.Dispose();
            }

            // Save the presentation before exiting
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
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