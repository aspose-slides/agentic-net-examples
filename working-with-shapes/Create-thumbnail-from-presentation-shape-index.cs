using System;
using System.IO;
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

            string presentationPath = args[0];
            string shapeIndexArg = args[1];
            int shapeIndex;

            // Check file existence
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Error: Presentation file does not exist.");
                return;
            }

            // Parse shape index
            if (!Int32.TryParse(shapeIndexArg, out shapeIndex) || shapeIndex < 0)
            {
                Console.WriteLine("Error: Invalid shape index.");
                return;
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath);
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Validate shape index range
                if (shapeIndex >= slide.Shapes.Count)
                {
                    Console.WriteLine("Error: Shape index out of range.");
                    pres.Dispose();
                    return;
                }

                // Get shape and generate thumbnail
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);

                // Save thumbnail as PNG
                string outputDirectory = Path.GetDirectoryName(presentationPath);
                string outputPng = Path.Combine(outputDirectory, $"shape_{shapeIndex}.png");
                shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

                // Save presentation before exit (no modifications made)
                pres.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine($"Thumbnail saved to {outputPng}");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Error: Presentation format not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}