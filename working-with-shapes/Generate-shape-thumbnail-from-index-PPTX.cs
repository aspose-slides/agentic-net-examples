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
            // Expect two arguments: presentation path and shape index
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ShapeThumbnailUtility <presentationPath> <shapeIndex>");
                return;
            }

            string presentationPath = args[0];
            string shapeIndexArg = args[1];
            int shapeIndex;

            // Validate shape index
            if (!Int32.TryParse(shapeIndexArg, out shapeIndex) || shapeIndex < 0)
            {
                Console.WriteLine("Invalid shape index.");
                return;
            }

            // Check if the presentation file exists
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine($"File not found: {presentationPath}");
                return;
            }

            Aspose.Slides.Presentation pres = null;
            try
            {
                // Load the presentation
                pres = new Aspose.Slides.Presentation(presentationPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine($"Error loading presentation: {ex.Message}");
                return;
            }

            // Ensure there is at least one slide
            if (pres.Slides.Count == 0)
            {
                Console.WriteLine("Presentation contains no slides.");
                pres.Dispose();
                return;
            }

            // Access the first slide (adjust as needed)
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Validate shape index within the slide
            if (shapeIndex >= slide.Shapes.Count)
            {
                Console.WriteLine($"Shape index out of range. Slide contains {slide.Shapes.Count} shapes.");
                pres.Dispose();
                return;
            }

            // Get the shape
            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

            // Generate thumbnail for the shape
            Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);

            // Prepare output file name
            string directory = Path.GetDirectoryName(presentationPath);
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(presentationPath);
            string outputPng = Path.Combine(directory, $"{fileNameWithoutExt}_shape{shapeIndex}.png");

            // Save the thumbnail image
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

            // Save the presentation before exit (optional: overwrite or new file)
            string outputPptx = Path.Combine(directory, $"{fileNameWithoutExt}_modified.pptx");
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            shapeImage.Dispose();
            pres.Dispose();

            Console.WriteLine($"Shape thumbnail saved to: {outputPng}");
            Console.WriteLine($"Presentation saved to: {outputPptx}");
        }
    }
}