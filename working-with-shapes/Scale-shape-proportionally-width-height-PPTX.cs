using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeScalingExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                var presentation = new Aspose.Slides.Presentation();

                var slide = presentation.Slides[0];

                // Add a rectangle shape
                var shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    50f,   // X position
                    50f,   // Y position
                    200f,  // Initial width
                    100f   // Initial height
                );

                // Desired width (height will be scaled proportionally)
                var desiredWidth = 400f;

                // Calculate scaling factor based on current width
                var scaleFactor = desiredWidth / shape.Width;

                // Apply proportional scaling
                shape.Width = shape.Width * scaleFactor;
                shape.Height = shape.Height * scaleFactor;

                // Save the presentation
                presentation.Save("ScaledShapePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}