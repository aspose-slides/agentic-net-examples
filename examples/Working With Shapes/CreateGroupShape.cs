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

        // Access the shape collection of the slide
        Aspose.Slides.IShapeCollection shapeCollection = slide.Shapes;

        // Add a new empty group shape to the slide
        Aspose.Slides.IGroupShape groupShape = shapeCollection.AddGroupShape();

        // Example: add a rectangle inside the group shape
        groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 0, 0, 100, 100);

        // Save the presentation to disk
        pres.Save("GroupShapeOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}