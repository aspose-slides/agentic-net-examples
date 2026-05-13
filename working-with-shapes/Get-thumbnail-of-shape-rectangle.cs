using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "ShapeThumbnailDemo.pptx";
        string outputPng = "ShapeThumbnail.png";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Capture the shape thumbnail with precise bounds
        IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        pres.Save(outputPptx, SaveFormat.Pptx);
    }
}