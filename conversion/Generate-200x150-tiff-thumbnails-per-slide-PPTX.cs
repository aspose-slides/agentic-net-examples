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
        // Output directory for thumbnails
        string outputDir = "Thumbnails";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Desired thumbnail dimensions
            int desiredWidth = 200;
            int desiredHeight = 150;

            // Calculate scaling factors based on slide size
            float scaleX = (float)desiredWidth / presentation.SlideSize.Size.Width;
            float scaleY = (float)desiredHeight / presentation.SlideSize.Size.Height;

            // Generate TIFF thumbnail for each slide
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[index];
                using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
                {
                    string outputPath = Path.Combine(outputDir, $"Slide_{index + 1}.tiff");
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Tiff);
                }
            }

            // Save presentation before exit (no modifications made)
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}