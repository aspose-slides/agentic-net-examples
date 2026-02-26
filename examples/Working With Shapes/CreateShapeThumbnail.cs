using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "output.pptx";
        string outputPng = "shape_thumbnail.png";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50,   // X position
            50,   // Y position
            200,  // Width
            100   // Height
        );

        // Set shape formatting
        shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

        // Generate thumbnail image for the shape
        Aspose.Slides.IImage shapeImage = shape.GetImage(
            Aspose.Slides.ShapeThumbnailBounds.Shape,
            1f,   // Scale X
            1f    // Scale Y
        );

        // Save the thumbnail as PNG
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}