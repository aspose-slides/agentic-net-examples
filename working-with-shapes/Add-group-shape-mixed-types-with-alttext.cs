using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an empty group shape to the slide
        Aspose.Slides.IGroupShape group = slide.Shapes.AddGroupShape();

        // Populate the group with different types of shapes
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 100, 50);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 200, 50, 80, 80);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Triangle, 300, 50, 100, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 200, 150);

        // Assign a collective alternative text description to the group shape
        ((Aspose.Slides.Shape)group).AlternativeText = "A group containing various shapes";

        // Save the presentation
        pres.Save("GroupShapeExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}