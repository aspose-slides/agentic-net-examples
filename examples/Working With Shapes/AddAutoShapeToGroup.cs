using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a group shape to the slide
        Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

        // Add an auto shape (rectangle) to the group shape
        Aspose.Slides.IAutoShape autoShape = groupShape.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            100f,   // X position
            100f,   // Y position
            200f,   // Width
            100f    // Height
        );

        // Save the presentation
        pres.Save("GroupShapeWithAutoShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}