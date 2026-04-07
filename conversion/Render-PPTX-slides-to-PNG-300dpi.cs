using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Directory to store PNG images
        string outputDir = "output";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Scale factor to achieve 300 DPI (default is 72 DPI)
            float scaleFactor = 300f / 72f;

            // Iterate through each slide
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Set slide background to transparent
                slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Transparent;

                // Render slide to PNG with the calculated scale
                Aspose.Slides.IImage image = slide.GetImage(scaleFactor, scaleFactor);
                string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.png");
                image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                image.Dispose();
            }

            // Save the presentation before exiting (as per requirement)
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}