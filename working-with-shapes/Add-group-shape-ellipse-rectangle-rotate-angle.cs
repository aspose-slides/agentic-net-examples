using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output directory and file path
        string outputDirectory = "Output" + Path.DirectorySeparatorChar;
        if (!Directory.Exists(outputDirectory))
            Directory.CreateDirectory(outputDirectory);
        string outputPath = Path.Combine(outputDirectory, "GroupShapeExample.pptx");

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a group shape to the slide
        IGroupShape groupShape = slide.Shapes.AddGroupShape();

        // Insert an ellipse inside the group shape
        groupShape.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 200, 100);

        // Insert a rectangle inside the group shape
        groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 250, 150, 100);

        // Set rotation angle for the group shape
        groupShape.Rotation = 45f;

        // Save the presentation (handle unsupported format exception)
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}