using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "ShapeThumbnail.pptx";
        string outputBmp = "ShapeThumbnail.bmp";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Generate shape thumbnail image
        IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);

        // Save the thumbnail as BMP, handling unsupported format
        try
        {
            shapeImage.Save(outputBmp, ImageFormat.Bmp);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Save the presentation before exit
        pres.Save(outputPptx, SaveFormat.Pptx);
    }
}