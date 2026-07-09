using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a triangle shape
            float triangleX = 100f;
            float triangleY = 100f;
            float triangleWidth = 200f;
            float triangleHeight = 200f;
            Aspose.Slides.IAutoShape triangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Triangle, triangleX, triangleY, triangleWidth, triangleHeight);

            // Rotate the triangle 45 degrees clockwise
            triangle.Rotation = 45f;

            // Verify new bounding box coordinates
            float newX = triangle.X;
            float newY = triangle.Y;
            float newWidth = triangle.Width;
            float newHeight = triangle.Height;

            Console.WriteLine("Triangle rotated to 45 degrees clockwise.");
            Console.WriteLine("Bounding box - X: {0}, Y: {1}, Width: {2}, Height: {3}", newX, newY, newWidth, newHeight);

            // Save the presentation
            string outputPath = "RotatedTriangle.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}