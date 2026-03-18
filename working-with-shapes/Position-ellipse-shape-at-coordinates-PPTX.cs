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
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add an ellipse shape at specified coordinates (X=100, Y=150) with width and height
            IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100f, 150f, 200f, 100f);

            // Adjust the X and Y offsets (e.g., move 20 points right and 30 points down)
            ellipse.X = ellipse.X + 20f;
            ellipse.Y = ellipse.Y + 30f;

            // Save the presentation
            presentation.Save("EllipsePresentation.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}