using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 150);

        // Set the fill type of the shape to picture
        shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;

        // Set the picture fill mode (e.g., Stretch)
        shape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;

        // Save the presentation
        presentation.Save("PictureFillModeExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}