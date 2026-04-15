using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        // Returns a thumbnail image of a shape identified by its unique ID.
        // The thumbnail is generated with the specified scaling factors.
        static IImage GetShapeThumbnail(Presentation presentation, uint shapeId, float scaleX, float scaleY)
        {
            // Search all slides for the shape with the given ID.
            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape.OfficeInteropShapeId == shapeId)
                    {
                        // Use the overload that requires ShapeThumbnailBounds and both scale factors.
                        return shape.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY);
                    }
                }
            }

            // Shape not found – return null.
            return null;
        }

        static void Main(string[] args)
        {
            // Path to the source presentation.
            string sourcePath = "input.pptx";

            // Verify that the file exists before attempting to load it.
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            // Parameters for the thumbnail generation.
            uint targetShapeId = 5;          // Example shape ID.
            float scaleX = 2.0f;            // Horizontal scaling factor.
            float scaleY = 2.0f;            // Vertical scaling factor.
            string outputImagePath = "shape_thumbnail.png";

            try
            {
                // Load the presentation.
                using (Presentation pres = new Presentation(sourcePath))
                {
                    // Generate the thumbnail.
                    using (IImage thumbnail = GetShapeThumbnail(pres, targetShapeId, scaleX, scaleY))
                    {
                        if (thumbnail != null)
                        {
                            // Save the thumbnail image.
                            thumbnail.Save(outputImagePath, ImageFormat.Png);
                            Console.WriteLine("Thumbnail saved to: " + outputImagePath);
                        }
                        else
                        {
                            Console.WriteLine("Shape with ID " + targetShapeId + " not found.");
                        }
                    }

                    // Save the presentation before exiting (even if unchanged).
                    pres.Save(sourcePath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // The file format is not supported.
                // Comment: format not supported.
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors (e.g., I/O, Aspose.Slides internal errors).
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}