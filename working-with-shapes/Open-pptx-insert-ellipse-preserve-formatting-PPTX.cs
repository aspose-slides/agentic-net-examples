using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing PPTX presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Insert an ellipse shape onto the slide
            Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Ellipse, // Shape type
                100, // X position (points)
                100, // Y position (points)
                200, // Width (points)
                150  // Height (points)
            );

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}