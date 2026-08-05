// -----------------------------------------------------------------------------
// Example: Create thumbnail from shape ID using C#
//
// Description:
// Demonstrates how to locate a shape by its OfficeInteropShapeId in a PowerPoint
// presentation, generate a thumbnail image for that shape with optional scaling,
// and save the image to disk. The example also shows how to load and save a
// presentation using Aspose.Slides for .NET in a console application.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Shape thumbnail, Shape ID, IImage, 
// GetShapeThumbnail, Presentation processing, Office automation
//
// Use Cases:
// - Generate a thumbnail for a specific shape identified by its ID.
// - Build utilities that extract visual representations of shapes from PPTX files.
// - Automate batch processing of presentations to create shape previews.
// - Integrate shape thumbnail generation into .NET applications or services.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailExample
{
    class Program
    {
        // Reusable method to get a shape thumbnail by shape ID and scaling factors
        public static IImage GetShapeThumbnail(Presentation presentation, uint shapeId, float scaleX, float scaleY)
        {
            // Iterate through all slides and shapes to find the matching shape
            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape.OfficeInteropShapeId == shapeId)
                    {
                        // Return the thumbnail image using the specified scale
                        return shape.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY);
                    }
                }
            }
            // Return null if shape not found
            return null;
        }

        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output thumbnail image path
            string outputImagePath = "shape_thumbnail.jpg";
            // Output presentation path (saved after processing)
            string outputPresentationPath = "output.pptx";
            // Shape identifier to locate (example value)
            uint targetShapeId = 5;
            // Scaling factors
            float scaleX = 1.0f;
            float scaleY = 1.0f;

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get the thumbnail for the specified shape
                    IImage thumbnail = GetShapeThumbnail(presentation, targetShapeId, scaleX, scaleY);
                    if (thumbnail != null)
                    {
                        // Save the thumbnail as JPEG
                        thumbnail.Save(outputImagePath, Aspose.Slides.ImageFormat.Jpeg);
                    }
                    else
                    {
                        Console.WriteLine("Shape with ID " + targetShapeId + " not found.");
                    }

                    // Save the presentation before exiting
                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
