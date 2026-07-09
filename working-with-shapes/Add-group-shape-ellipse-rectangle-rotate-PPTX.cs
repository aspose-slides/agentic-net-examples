using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output directory and file path
        string outputDir = "Output" + Path.DirectorySeparatorChar;
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);
        string outputPath = Path.Combine(outputDir, "GroupShapeRotation_out.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a group shape to the slide
        Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape();

        // Add an ellipse inside the group shape
        groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 150, 100);

        // Add a rectangle inside the group shape
        groupShape.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 300, 100, 150, 100);

        // Set rotation angle for the group shape (45 degrees)
        groupShape.Rotation = 45;

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}