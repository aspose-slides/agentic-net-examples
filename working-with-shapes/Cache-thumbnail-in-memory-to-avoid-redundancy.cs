// -----------------------------------------------------------------------------
// Example: Cache shape thumbnails in memory to avoid redundant generation
//
// Description:
// Demonstrates how to cache shape thumbnails while processing a PowerPoint
// presentation using Aspose.Slides for .NET. The program creates a sample PPTX
// if none exists, generates thumbnails for each shape on the first slide,
// stores them in a dictionary, saves the thumbnails as PNG files, and saves
// the presentation without refreshing its thumbnail using the cached images.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Cache, Thumbnail, Memory, Shape
//
// Use Cases:
// - Reduce processing time by caching shape thumbnails during batch operations.
// - Build .NET tools that generate or manipulate shape images from PPTX files.
// - Automate thumbnail extraction and reuse in presentation workflows.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Collections.Generic;

namespace ThumbnailCacheExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = "input.pptx";
            string outputFileName = "output.pptx";
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

            // Create a sample presentation if the input file does not exist
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePresentation = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePresentation.Slides[0];
                    Aspose.Slides.IAutoShape sampleShape = (Aspose.Slides.IAutoShape)sampleSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);
                    sampleShape.TextFrame.Text = "Sample Shape";
                    samplePresentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePresentation.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error creating sample presentation: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                Environment.Exit(1);
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file format is not supported.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                Environment.Exit(1);
            }

            Dictionary<int, Aspose.Slides.IImage> thumbnailCache = new Dictionary<int, Aspose.Slides.IImage>();

            try
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    int shapeKey = shape.GetHashCode();

                    Aspose.Slides.IImage thumbnailImage;
                    if (!thumbnailCache.TryGetValue(shapeKey, out thumbnailImage))
                    {
                        thumbnailImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1.0f, 1.0f);
                        thumbnailCache[shapeKey] = thumbnailImage;
                    }

                    string pngFileName = $"shape_{shapeKey}.png";
                    string pngPath = Path.Combine(Directory.GetCurrentDirectory(), pngFileName);
                    thumbnailImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing shapes: " + ex.Message);
                if (presentation != null)
                {
                    presentation.Dispose();
                }
                Environment.Exit(1);
            }

            try
            {
                Aspose.Slides.Export.PptxOptions saveOptions = new Aspose.Slides.Export.PptxOptions();
                saveOptions.RefreshThumbnail = false;
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, saveOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
                if (presentation != null)
                {
                    presentation.Dispose();
                }
                Environment.Exit(1);
            }

            // Dispose cached images
            foreach (Aspose.Slides.IImage img in thumbnailCache.Values)
            {
                img.Dispose();
            }

            if (presentation != null)
            {
                presentation.Dispose();
            }

            Environment.Exit(0);
        }
    }
}
