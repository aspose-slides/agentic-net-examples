// -----------------------------------------------------------------------------
// Example: Generate Shape Thumbnail with Missing Shape ID Handling
//
// Description:
// Demonstrates how to create a PNG thumbnail for a specific shape in a PowerPoint
// presentation using Aspose.Slides for .NET, while safely handling cases where the
// requested shape ID does not exist. The program creates a sample PPTX if none is
// provided, searches for the shape by OfficeInteropShapeId, generates the thumbnail,
// and saves both the presentation and the image.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, shape thumbnail, missing shape ID, error handling
//
// Use Cases:
// - Automate extraction of shape images for documentation purposes.
// - Build utilities that need to verify shape existence before processing.
// - Integrate shape thumbnail generation into larger .NET workflows with robust error handling.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ShapeThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPptxPath = args.Length > 1 ? args[1] : "output.pptx";
            string outputPngPath = args.Length > 2 ? args[2] : "shape.png";
            uint shapeId = 0;
            if (args.Length > 3)
            {
                uint.TryParse(args[3], out shapeId);
            }

            try
            {
                // Create a sample presentation if the input file does not exist
                if (!File.Exists(inputPath))
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide sampleSlide = samplePres.Slides[0];
                    Aspose.Slides.IShape sampleShape = sampleSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 300f, 150f);
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    if (shapeId == 0)
                    {
                        shapeId = sampleShape.OfficeInteropShapeId;
                    }
                    samplePres.Dispose();
                }

                // Verify input file exists before loading
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Input file not found: " + inputPath);
                    Environment.Exit(1);
                }

                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
                if (pres.Slides.Count == 0)
                {
                    Console.WriteLine("The presentation contains no slides.");
                    pres.Dispose();
                    Environment.Exit(1);
                }

                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Find the shape with the specified OfficeInteropShapeId
                Aspose.Slides.IShape targetShape = null;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape.OfficeInteropShapeId == shapeId)
                    {
                        targetShape = shape;
                        break;
                    }
                }

                if (targetShape == null)
                {
                    Console.WriteLine("Shape with ID " + shapeId + " not found on the first slide.");
                    pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    pres.Dispose();
                    Environment.Exit(1);
                }

                // Generate thumbnail for the found shape
                Aspose.Slides.IImage shapeImage = targetShape.GetImage(
                    Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);
                shapeImage.Save(outputPngPath, Aspose.Slides.ImageFormat.Png);
                shapeImage.Dispose();

                // Save the (potentially unchanged) presentation
                pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Thumbnail saved to: " + outputPngPath);
                Console.WriteLine("Presentation saved to: " + outputPptxPath);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The specified file format is not supported for saving.");
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
