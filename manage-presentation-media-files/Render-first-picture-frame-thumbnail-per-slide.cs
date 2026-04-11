using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        var inputPath = "input.pptx";
        // Output directory for thumbnails
        var outputDir = "Thumbnails";

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
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                var slide = presentation.Slides[i];
                Aspose.Slides.IPictureFrame pictureFrame = null;

                // Find the first picture frame on the slide
                foreach (var shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.IPictureFrame)
                    {
                        pictureFrame = (Aspose.Slides.IPictureFrame)shape;
                        break;
                    }
                }

                // If a picture frame is found, render its thumbnail
                if (pictureFrame != null)
                {
                    using (var image = pictureFrame.GetImage())
                    {
                        var thumbnailPath = Path.Combine(outputDir, $"slide_{slide.SlideNumber}_thumb.png");
                        image.Save(thumbnailPath, Aspose.Slides.ImageFormat.Png);
                    }
                }
            }

            // Save presentation before exit
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
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