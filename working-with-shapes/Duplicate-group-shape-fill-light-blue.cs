using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a group shape to the slide
        Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

        // Add some shapes inside the group
        groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 0, 0, 100, 100);
        groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 120, 0, 100, 100);

        // Clone the group shape and reposition it
        Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(groupShape, 300, 200);

        // Change fill of the cloned shape to light blue
        clonedShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        clonedShape.FillFormat.SolidFillColor.Color = Color.LightBlue;

        // Save the presentation
        presentation.Save("GroupShapeClone.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}