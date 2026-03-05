using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CustomShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape to the slide
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50f,   // X position
                150f,  // Y position
                300f,  // Width
                200f   // Height
            );

            // Optionally set shape properties (e.g., name)
            shape.Name = "CustomRectangle";

            // Save the presentation
            presentation.Save("CustomShapePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}