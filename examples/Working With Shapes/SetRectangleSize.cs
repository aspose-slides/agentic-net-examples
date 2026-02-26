using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape at position (50,50) with initial size (100,50)
        Aspose.Slides.IShape rectangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 100f, 50f);

        // Set the rectangle's size to width=200 and height=100
        rectangle.Width = 200f;
        rectangle.Height = 100f;

        // Save the presentation before exiting
        presentation.Save("SetRectangleSize_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}