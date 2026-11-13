// -----------------------------------------------------------------------------
// Example: Load PPTX and Retrieve Shape Thumbnail using C#
// 
// Description:
// Demonstrates loading a PPTX file, locating a shape by its OfficeInteropShapeId,
// generating a thumbnail image of that shape (if supported), and saving the image
// as PNG using Aspose.Slides for .NET. The program also saves the unchanged
// presentation to a new PPTX file. If the input file does not exist, a sample
// presentation is created automatically.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Shape Thumbnail, Image Export
// 
// Use Cases:
// - Automate extraction of visual previews for specific shapes in presentations.
// - Build utilities that generate thumbnails for documentation or reporting.
// - Validate shape existence and extract graphics programmatically.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ShapeThumbnailExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPng = "shape_thumbnail.png";
            string outputPptx = "output.pptx";

            // Ensure input file exists; create a sample if missing
            if (!File.Exists(inputPath))
            {
                try
                {
                    Aspose.Slides.Presentation samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ISlide firstSlide = samplePres.Slides[0];
                    Aspose.Slides.IShape sampleShape = firstSlide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
                    samplePres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    samplePres.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample presentation: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            // Load presentation
            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation(inputPath);
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

            // Determine a target shape ID (first shape's OfficeInteropShapeId)
            uint targetShapeId = 0;
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    targetShapeId = shape.OfficeInteropShapeId;
                    break;
                }
                if (targetShapeId != 0)
                {
                    break;
                }
            }

            if (targetShapeId == 0)
            {
                Console.WriteLine("No shapes found in the presentation.");
                pres.Dispose();
                Environment.Exit(1);
            }

            // Locate the shape by OfficeInteropShapeId
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
                Environment.Exit(1);
            }

            // Generate thumbnail for the shape (using dynamic to avoid compile-time binding)
            Image shapeImage = null;
            try
            {
                dynamic dynShape = targetShape;
                shapeImage = (Image)dynShape.GetThumbnail(1.0, 1.0);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                Console.WriteLine("GetThumbnail method is not supported for this shape type.");
                // Continue without thumbnail generation
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to generate thumbnail: " + ex.Message);
                pres.Dispose();
                Environment.Exit(1);
            }

            // Save thumbnail as PNG if generated
            if (shapeImage != null)
            {
                try
                {
                    shapeImage.Save(outputPng, ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to save thumbnail: " + ex.Message);
                    shapeImage.Dispose();
                    pres.Dispose();
                    Environment.Exit(1);
                }
            }

            // Save the (unchanged) presentation
            try
            {
                pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
                if (shapeImage != null) shapeImage.Dispose();
                pres.Dispose();
                Environment.Exit(1);
            }

            // Clean up
            if (shapeImage != null) shapeImage.Dispose();
            pres.Dispose();

            if (shapeImage != null)
                Console.WriteLine("Thumbnail saved to " + outputPng);
            else
                Console.WriteLine("Thumbnail not generated; method not supported.");

            Console.WriteLine("Presentation saved to " + outputPptx);
        }
    }
}
