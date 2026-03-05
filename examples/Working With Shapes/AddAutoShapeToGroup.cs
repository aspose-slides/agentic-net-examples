using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var pres = new Aspose.Slides.Presentation();

        // Get the first slide
        var slide = pres.Slides[0];

        // Add a group shape to the slide
        var group = slide.Shapes.AddGroupShape();

        // Add initial auto shapes to the group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 100, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 500, 100, 100, 100);

        // Add another auto shape to the same group
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 400, 200, 80, 80);

        // Save the presentation
        pres.Save("GroupShapeWithAdditionalShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}