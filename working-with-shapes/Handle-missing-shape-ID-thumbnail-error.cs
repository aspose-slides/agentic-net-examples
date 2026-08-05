// -----------------------------------------------------------------------------
// Example: Handle missing shape ID thumbnail error using C#
//
// Description:
// Demonstrates how to generate a thumbnail for a specific shape in a PowerPoint
// presentation using Aspose.Slides for .NET and how to handle the case where the
// requested shape ID does not exist. The example loads a PPTX file, searches for
// a shape by its OfficeInteropShapeId, creates a PNG thumbnail if found, and
// saves both the modified presentation and the thumbnail image.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Handle, Missing, Shape,
// Thumbnail, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate generation of shape thumbnails while safely handling missing IDs.
// - Build C# utilities for PowerPoint presentation analysis and image extraction.
// - Integrate shape thumbnail creation into .NET applications with error handling.
// - Validate shape existence before processing in automated PPTX workflows.
// -----------------------------------------------------------------------------
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
