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

        // Add a rectangle shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Generate a thumbnail of the shape with custom scaling
        IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
        // Save the thumbnail as PNG
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        try
        {
            pres.Save(outputPptx, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}