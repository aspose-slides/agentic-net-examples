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

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangular AutoShape with specified position and size
            IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100f, 100f, 200f, 100f);

            // Set fill to no fill
            rectangle.FillFormat.FillType = FillType.NoFill;

            // Set line width
            rectangle.LineFormat.Width = 2f;

            // Save the presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}