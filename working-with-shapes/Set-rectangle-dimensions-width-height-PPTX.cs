using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Desired dimensions in points
            var rectWidth = 400f;
            var rectHeight = 200f;

            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Add a rectangle shape with the specified dimensions
            var rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, rectWidth, rectHeight);

            // Optionally, modify the shape's size after creation
            rectangle.Width = rectWidth;
            rectangle.Height = rectHeight;

            // Save the presentation
            presentation.Save("ConfiguredRectangle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}