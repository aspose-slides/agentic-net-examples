using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output paths
        string inputPath = "input.pptx";
        string outputPresentationPath = "output_A3.pptx";
        string outputImageFolder = "Images";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure output folder exists
        if (!Directory.Exists(outputImageFolder))
        {
            Directory.CreateDirectory(outputImageFolder);
        }

        Presentation presentation = null;
        try
        {
            // Load presentation
            presentation = new Presentation(inputPath);
        }
        catch (Exception)
        {
            // Possibly unsupported format
            Console.WriteLine("Failed to load presentation. Format not supported.");
            return;
        }

        // Set slide size to A3 with content scaling
        presentation.SlideSize.SetSize(SlideSizeType.A3Paper, SlideSizeScaleType.EnsureFit);

        // Save modified presentation
        try
        {
            presentation.Save(outputPresentationPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to save presentation.");
        }

        // Export each slide to JPEG
        int scaleX = 1;
        int scaleY = 1;
        foreach (ISlide slide in presentation.Slides)
        {
            using (IImage image = slide.GetImage(scaleX, scaleY))
            {
                string imagePath = Path.Combine(outputImageFolder, string.Format("Slide_{0}.jpg", slide.SlideNumber));
                image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
            }
        }

        // Clean up
        if (presentation != null)
        {
            presentation.Dispose();
        }
    }
}