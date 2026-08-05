// -----------------------------------------------------------------------------
// Example: Cache thumbnail in memory to avoid redundancy using C#
//
// Description:
// Demonstrates how to cache shape thumbnails in memory to avoid redundant
// generation when processing a PowerPoint presentation with Aspose.Slides for .NET.
// The example loads a PPTX file, generates thumbnails for each shape on the first
// slide, stores them in a dictionary, saves the thumbnails as PNG files, and
// saves the presentation without refreshing its thumbnail using the cached images.
// This pattern helps improve performance in automation scenarios that require
// repeated access to shape images.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Cache, Thumbnail, Memory, Avoid,
// Presentation Processing, Office Automation, Shape, Image, PNG
//
// Use Cases:
// - Reduce processing time by caching shape thumbnails during batch operations.
// - Build .NET tools that generate or manipulate shape images from PPTX files.
// - Automate thumbnail extraction and reuse in presentation workflows.
// - Optimize memory and CPU usage when handling large presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailCacheExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputFileName = "input.pptx";
            string outputFileName = "output.pptx";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // TODO: handle unsupported format
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                // General exception handling for loading
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Cache for shape thumbnails (keyed by OfficeInteropShapeId)
            Dictionary<ulong, Aspose.Slides.IImage> thumbnailCache = new Dictionary<ulong, Aspose.Slides.IImage>();

            // Process shapes on the first slide as an example
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                ulong shapeId = shape.OfficeInteropShapeId;

                Aspose.Slides.IImage thumbnailImage;
                if (!thumbnailCache.TryGetValue(shapeId, out thumbnailImage))
                {
                    // Thumbnail not cached, generate and store it
                    thumbnailImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);
                    thumbnailCache[shapeId] = thumbnailImage;
                }

                // Save thumbnail to PNG file
                string pngFileName = $"shape_{shapeId}.png";
                string pngPath = Path.Combine(Directory.GetCurrentDirectory(), pngFileName);
                thumbnailImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);
            }

            // Save presentation without refreshing the thumbnail (uses cached thumbnails)
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, new Aspose.Slides.Export.PptxOptions
                {
                    RefreshThumbnail = false
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose resources
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
