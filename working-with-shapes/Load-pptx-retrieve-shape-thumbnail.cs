using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output PNG thumbnail path
            string outputPng = "shape_thumbnail.png";
            // Output PPTX path after processing
            string outputPptx = "output.pptx";
            // Shape ID to retrieve (example value)
            uint targetShapeId = 5;

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
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
                Console.WriteLine("The file format is not supported.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Find the shape with the specified ID
            Aspose.Slides.IShape targetShape = null;
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape.OfficeInteropShapeId == targetShapeId)
                    {
                        targetShape = shape;
                        break;
                    }
                }
                if (targetShape != null)
                {
                    break;
                }
            }

            if (targetShape == null)
            {
                Console.WriteLine("Shape with ID " + targetShapeId + " not found.");
                pres.Dispose();
                return;
            }

            // Generate default thumbnail for the shape
            Aspose.Slides.IImage shapeImage = targetShape.GetImage();

            // Save thumbnail as PNG
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

            // Save the (unchanged) presentation before exit
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
            Console.WriteLine("Thumbnail saved to " + outputPng);
        }
    }
}