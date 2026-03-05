using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape at position (100,150) with width 200 and height 100
        Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 100f, 150f, 200f, 100f);

        // Save the presentation
        presentation.Save("RectanglePositioned.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}