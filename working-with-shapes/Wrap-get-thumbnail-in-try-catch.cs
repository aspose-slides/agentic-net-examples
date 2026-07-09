using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "ShapeThumbnailDemo.pptx";
        string outputPng = "ShapeThumbnail.png";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 150);
        shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

        // Generate thumbnail for the shape and handle unsupported types
        Aspose.Slides.IImage shapeImage = null;
        try
        {
            shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);
        }
        catch (Exception ex)
        {
            // Gracefully handle errors (e.g., unsupported shape type)
            Console.WriteLine("Error generating shape thumbnail: " + ex.Message);
        }

        // Save the presentation before exiting
        pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}