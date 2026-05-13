using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input arguments: input PPTX path, output PPTX path, output PNG path, shape ID
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPptxPath = args.Length > 1 ? args[1] : "output.pptx";
            string outputPngPath = args.Length > 2 ? args[2] : "shape.png";
            uint shapeId = 0;
            if (args.Length > 3)
            {
                uint.TryParse(args[3], out shapeId);
            }

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Access first slide
                ISlide slide = pres.Slides[0];

                // Find shape by OfficeInteropShapeId
                IShape targetShape = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape.OfficeInteropShapeId == shapeId)
                    {
                        targetShape = shape;
                        break;
                    }
                }

                if (targetShape == null)
                {
                    // Handle missing shape ID
                    Console.WriteLine("Shape with ID " + shapeId + " not found on the slide.");
                }
                else
                {
                    // Generate thumbnail for the shape
                    IImage shapeImage = targetShape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
                    shapeImage.Save(outputPngPath, Aspose.Slides.ImageFormat.Png);
                }

                // Save the presentation before exit
                pres.Save(outputPptxPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported for saving.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}