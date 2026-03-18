using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EllipseDimensionsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add an ellipse shape with initial dimensions
                IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100f, 100f, 200f, 150f);

                // Define the desired width and height of the ellipse
                ellipse.Width = 300f;   // Width in points
                ellipse.Height = 200f;  // Height in points

                // Save the presentation
                presentation.Save("EllipseShape.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}