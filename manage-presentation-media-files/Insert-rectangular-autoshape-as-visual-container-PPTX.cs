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
            var presentation = new Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Insert a rectangular AutoShape as a visual container
            var container = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 300);

            // Add a text frame to the rectangle (optional)
            container.AddTextFrame("Container");

            // Save the presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}