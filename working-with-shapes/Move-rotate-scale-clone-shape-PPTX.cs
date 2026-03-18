using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeTransformations
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add an AutoShape (rectangle) to the slide
                    IAutoShape originalShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

                    // Move the shape by setting new X and Y coordinates
                    originalShape.X = 150;
                    originalShape.Y = 150;

                    // Rotate the shape (clockwise 45 degrees)
                    originalShape.Rotation = 45;

                    // Scale the shape by adjusting Width and Height (increase by 50%)
                    originalShape.Width = originalShape.Width * 1.5f;
                    originalShape.Height = originalShape.Height * 1.5f;

                    // Clone the transformed shape and place the clone at a different location
                    IShape clonedShape = slide.Shapes.AddClone(originalShape, 400, 150);

                    // Optionally, rotate the cloned shape differently
                    clonedShape.Rotation = -30;

                    // Save the presentation
                    presentation.Save("ShapeTransformations_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}