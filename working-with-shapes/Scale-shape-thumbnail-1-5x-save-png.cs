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
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape to the slide
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Scaling factor for the thumbnail (1.5x)
        float scaleFactor = 1.5f;

        // Generate the shape thumbnail with the scaling factor
        IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, scaleFactor, scaleFactor);

        // Save the thumbnail as PNG
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation before exiting
        pres.Save(outputPptx, SaveFormat.Pptx);
    }
}