using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                Presentation presentation = new Presentation("input.pptx");

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to the slide
                IAutoShape rectangle = slide.Shapes.AddAutoShape(
                    ShapeType.Rectangle,
                    100F,   // X position
                    100F,   // Y position
                    200F,   // Width
                    100F    // Height
                );

                // Optionally, add a text frame to the rectangle
                rectangle.AddTextFrame("Sample Text");

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}