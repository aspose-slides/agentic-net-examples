using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Validate arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ShapeThumbnailUtility <presentationPath> <shapeIndex>");
                return;
            }

            string inputPath = args[0];
            string shapeIndexArg = args[1];
            int shapeIndex;

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: File \"{inputPath}\" does not exist.");
                return;
            }

            // Parse shape index
            if (!Int32.TryParse(shapeIndexArg, out shapeIndex) || shapeIndex < 0)
            {
                Console.WriteLine("Error: Shape index must be a non‑negative integer.");
                return;
            }

            Aspose.Slides.Presentation pres = null;
            try
            {
                // Load presentation
                pres = new Aspose.Slides.Presentation(inputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // The presentation format is not supported by Aspose.Slides.
                Console.WriteLine("Error: The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading presentation: {ex.Message}");
                return;
            }

            // Ensure there is at least one slide
            if (pres.Slides.Count == 0)
            {
                Console.WriteLine("Error: Presentation contains no slides.");
                pres.Dispose();
                return;
            }

            // Access first slide (index 0)
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Validate shape index within slide
            if (shapeIndex >= slide.Shapes.Count)
            {
                Console.WriteLine($"Error: Shape index {shapeIndex} is out of range. Slide contains {slide.Shapes.Count} shapes.");
                pres.Dispose();
                return;
            }

            // Get the shape
            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

            // Generate thumbnail image for the shape
            Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);

            // Determine output PNG path
            string outputDirectory = Path.GetDirectoryName(inputPath);
            string inputFileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPng = Path.Combine(outputDirectory, $"{inputFileNameWithoutExt}_shape_{shapeIndex}.png");

            // Save the thumbnail image
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);
            Console.WriteLine($"Shape thumbnail saved to: {outputPng}");

            // Save presentation before exit (no changes made, but fulfills requirement)
            string outputPptx = Path.Combine(outputDirectory, $"{inputFileNameWithoutExt}_modified.pptx");
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine($"Presentation saved to: {outputPptx}");

            // Clean up
            pres.Dispose();
        }
    }
}