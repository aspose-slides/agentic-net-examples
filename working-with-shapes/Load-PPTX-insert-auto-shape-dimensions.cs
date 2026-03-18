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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Insert a custom auto shape (Rectangle) at specified position and size
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    100f,   // X coordinate
                    150f,   // Y coordinate
                    300f,   // Width
                    200f    // Height
                );

                // Optionally add a text frame to the shape
                autoShape.AddTextFrame("Custom Shape");

                // Save the modified presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}