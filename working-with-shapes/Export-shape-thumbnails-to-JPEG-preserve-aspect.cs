using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "ShapeThumbnailDemo.pptx";
        string outputJpeg = "ShapeThumbnail.jpg";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape to the slide
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Preserve the original aspect ratio by using equal scaling factors for X and Y
        float scale = 1f; // Full size (no scaling)
        IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, scale, scale);

        // Save the shape thumbnail as JPEG
        shapeImage.Save(outputJpeg, Aspose.Slides.ImageFormat.Jpeg);

        // Save the presentation before exiting
        pres.Save(outputPptx, SaveFormat.Pptx);
    }
}