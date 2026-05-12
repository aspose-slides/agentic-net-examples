using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        string inputPath = "input.pptx";
        // Output folder for thumbnails
        string outputFolder = "Thumbnails";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Desired thumbnail dimensions
            System.Drawing.Size thumbnailSize = new System.Drawing.Size(200, 150);

            // Generate thumbnail for each slide
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[index];
                using (Aspose.Slides.IImage image = slide.GetImage(thumbnailSize))
                {
                    string outputPath = Path.Combine(outputFolder, $"Slide_{index + 1}.jpg");
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Save presentation before exit (no modifications made)
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
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