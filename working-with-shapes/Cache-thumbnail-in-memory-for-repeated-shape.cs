using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file names
        string inputFileName = "input.pptx";
        string outputFileName = "output.pptx";

        // Build full paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Cache for shape thumbnails
            Dictionary<uint, Aspose.Slides.IImage> thumbnailCache = new Dictionary<uint, Aspose.Slides.IImage>();

            // Iterate through slides and shapes
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    uint shapeId = shape.UniqueId;

                    Aspose.Slides.IImage thumbnail;
                    if (!thumbnailCache.TryGetValue(shapeId, out thumbnail))
                    {
                        // Generate thumbnail and store in cache
                        thumbnail = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);
                        thumbnailCache[shapeId] = thumbnail;
                    }

                    // Example usage: save thumbnail to PNG file
                    string thumbFileName = $"shape_{slideIndex}_{shapeIndex}.png";
                    thumbnail.Save(thumbFileName, Aspose.Slides.ImageFormat.Png);
                }
            }

            // Save presentation without refreshing its thumbnail (uses cached thumbnails)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, new Aspose.Slides.Export.PptxOptions
            {
                RefreshThumbnail = false
            });

            // Dispose presentation
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