using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RotateTriangleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a triangle shape (auto shape) to the slide
                // Parameters: shape type, X, Y, width, height (all in points)
                Aspose.Slides.IAutoShape triangle = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Triangle,
                    100f,   // X position
                    100f,   // Y position
                    200f,   // Width
                    200f    // Height
                );

                // Rotate the triangle 45 degrees clockwise
                triangle.Rotation = 45f;

                // Retrieve the shape's frame to get the bounding box after rotation
                Aspose.Slides.IShapeFrame frame = triangle.Frame;

                // The Rectangle property provides the bounding box (X, Y, Width, Height)
                System.Drawing.RectangleF boundingBox = frame.Rectangle;

                // Output the new bounding box coordinates
                Console.WriteLine("Bounding Box after 45° rotation:");
                Console.WriteLine("X: " + boundingBox.X);
                Console.WriteLine("Y: " + boundingBox.Y);
                Console.WriteLine("Width: " + boundingBox.Width);
                Console.WriteLine("Height: " + boundingBox.Height);

                // Save the presentation
                try
                {
                    string outputPath = "RotatedTriangle.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to " + outputPath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    // Comment: The requested save format is not supported.
                }
                catch (Exception ex)
                {
                    // Handle other possible exceptions (e.g., I/O errors)
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}