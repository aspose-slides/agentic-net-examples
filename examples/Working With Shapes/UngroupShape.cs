using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a group shape and some shapes inside it
        Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();
        groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
        groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 150, 150, 100, 100);

        // Ungroup: clone each inner shape to the slide and then remove the group
        for (int i = 0; i < groupShape.Shapes.Count; i++)
        {
            Aspose.Slides.IShape innerShape = groupShape.Shapes[i];
            slide.Shapes.AddClone(innerShape);
        }
        slide.Shapes.Remove(groupShape);

        // Save the presentation
        presentation.Save("UngroupedShape_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}