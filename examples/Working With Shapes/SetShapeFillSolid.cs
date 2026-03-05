using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle autoshape to the slide
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 200, 100);

            // Set the shape's fill type to solid
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;

            // Optionally set a solid fill color (e.g., red)
            shape.FillFormat.SolidFillColor.Color = Color.Red;

            // Save the presentation before exiting
            presentation.Save("ShapeSolidFill.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}