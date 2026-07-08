using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output directory and ensure it exists
        string outDir = "Output" + System.IO.Path.DirectorySeparatorChar;
        if (!System.IO.Directory.Exists(outDir))
        {
            System.IO.Directory.CreateDirectory(outDir);
        }

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Access the shape collection of the slide
        Aspose.Slides.IShapeCollection shapes = slide.Shapes;

        // Add an empty group shape
        Aspose.Slides.IGroupShape group = shapes.AddGroupShape();

        // Populate the group with different types of shapes
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 100, 50);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 200, 50, 80, 80);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Triangle, 100, 150, 120, 100);
        group.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 10, 10, 300, 0);

        // Optionally set the group shape's frame
        group.Frame = new Aspose.Slides.ShapeFrame(0, 0, 400, 300, Aspose.Slides.NullableBool.False, Aspose.Slides.NullableBool.False, 0);

        // Assign a collective alternative text description to the group
        group.AlternativeText = "A group of various shapes";

        // Save the presentation
        string outPath = outDir + "GroupShapeExample.pptx";
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}