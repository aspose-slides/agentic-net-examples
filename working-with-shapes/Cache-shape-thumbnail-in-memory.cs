using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailCacheExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string inputFileName = "input.pptx";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "Thumbnails");
            string outputPresentation = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output folder exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Cache for shape thumbnails (keyed by OfficeInteropShapeId)
            Dictionary<uint, IImage> thumbnailCache = new Dictionary<uint, IImage>();

            // Load presentation
            Presentation presentation = null;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Process shapes on the first slide as an example
            ISlide slide = presentation.Slides[0];
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                IShape shape = slide.Shapes[i];
                uint shapeId = shape.OfficeInteropShapeId;

                // Check cache
                if (!thumbnailCache.ContainsKey(shapeId))
                {
                    // Generate thumbnail (default bounds, full scale)
                    IImage thumbnail = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
                    thumbnailCache[shapeId] = thumbnail;
                }

                // Retrieve cached thumbnail
                IImage cachedImage = thumbnailCache[shapeId];
                string thumbnailPath = Path.Combine(outputFolder, $"shape_{shapeId}.png");
                cachedImage.Save(thumbnailPath, Aspose.Slides.ImageFormat.Png);
            }

            // Save presentation before exit
            try
            {
                presentation.Save(outputPresentation, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Cleanup
            presentation.Dispose();
        }
    }
}